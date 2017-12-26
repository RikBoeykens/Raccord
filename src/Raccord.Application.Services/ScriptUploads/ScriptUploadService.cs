using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.ScriptUploads;
using Raccord.Application.Services.Characters;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Data.EntityFramework.Repositories.Scenes.Actions;
using Raccord.Data.EntityFramework.Repositories.Scenes.Dialogues;
using Raccord.Data.EntityFramework.Repositories.ScriptUploads;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Scenes.Actions;
using Raccord.Domain.Model.Scenes.Dialogues;
using Raccord.Domain.Model.ScriptUploads;

namespace Raccord.Application.Services.ScriptUploads
{
  public class ScriptUploadService : IScriptUploadService
  {
    private readonly IScriptUploadRepository _scriptUploadRepository;
    private readonly ICharacterRepository _characterRepository;
    private readonly ICharacterSceneRepository _characterSceneRepository;
    private readonly ISceneActionRepository _sceneActionRepository;
    private readonly ISceneDialogueRepository _sceneDialogueRepository;
    private readonly ISceneService _sceneService;
    private const string _sceneHeadingParagraph = "Scene Heading";
    private const string _characterParagraph = "Character";
    private const string _actionParagraph = "Action";
    private const string _dialogueParagraph = "Dialogue";
    private const string _textElement = "Text";
    private string _intExtSeparator;
    private string _dayNightSeparator;

    public ScriptUploadService(
      IScriptUploadRepository scriptUploadRepository,
      ICharacterRepository characterRepository,
      ICharacterSceneRepository characterSceneRepository,
      ISceneActionRepository sceneActionRepository,
      ISceneDialogueRepository sceneDialogueRepository,
      ISceneService sceneService
      ){
        _scriptUploadRepository = scriptUploadRepository;
        _sceneActionRepository = sceneActionRepository;
        _sceneDialogueRepository = sceneDialogueRepository;
        _characterRepository = characterRepository;
        _characterSceneRepository = characterSceneRepository;
        _sceneService = sceneService;
    }

    public FullScriptUploadDto Get(long ID)
    {
      var scriptUpload = _scriptUploadRepository.GetFull(ID);

      return scriptUpload.TranslateFull();
    }

    public long UploadScript(ScriptUploadRequestDto request)
    {
      XDocument xml = XDocument.Load(request.FileContent);

      var xmlFinalDraft = xml.Element("FinalDraft");

      var xmlSmartType = xmlFinalDraft.Element("SmartType");
      GetSeparators(xmlSmartType);

      var newScriptUpload = new ScriptUpload
      {
        FileName = request.FileName,
        Start = DateTime.UtcNow,
        ProjectID = request.ProjectID
      };

      _scriptUploadRepository.Add(newScriptUpload);
      _scriptUploadRepository.Commit();

      try
      {
        ParseParagraphs(xmlFinalDraft.Element("Content").Elements("Paragraph"), request.ProjectID, newScriptUpload.ID);
      }
      finally
      {
        var createdScriptUpload = _scriptUploadRepository.GetSingle(newScriptUpload.ID);
        createdScriptUpload.End = DateTime.UtcNow;
        _scriptUploadRepository.Edit(createdScriptUpload);
        _scriptUploadRepository.Commit();
      }
      return newScriptUpload.ID;
    }

    private void GetSeparators(XElement xmlSmartType)
    {
      _intExtSeparator = xmlSmartType.Element("SceneIntros").Attribute("Separator").Value;

      _dayNightSeparator = xmlSmartType.Element("TimesOfDay").Attribute("Separator").Value;
    }

    public void ParseParagraphs(IEnumerable<XElement> xmlParagraphs, long projectID, long scriptUploadID)
    {
      long currentSceneId = default(long);
      long currentCharacterId = default(long);
      var currentSceneOrder = 0;

      foreach(var paragraph in xmlParagraphs)
      {
        switch(paragraph.Attribute("Type").Value)
        {
          case _sceneHeadingParagraph:
            var newScene = ParseSceneHeading(paragraph, projectID, scriptUploadID);
            currentSceneId = newScene.ID;
            break;
          case _characterParagraph:
            var response = ParseCharacter(paragraph, currentSceneId, projectID, scriptUploadID);
            currentCharacterId = response.Character.ID;
            break;
          case _dialogueParagraph:
            if(paragraph.ElementsBeforeSelf().LastOrDefault().Attribute("Type")?.Value == _characterParagraph)
            {
              ParseDialogue(paragraph, currentSceneId, currentCharacterId, currentSceneOrder, projectID);
              currentSceneOrder++;
            }
            break;
          case _actionParagraph:
            ParseAction(paragraph, currentSceneId, currentSceneOrder, projectID);
              currentSceneOrder++;
            break;
          default:
            break;
        }
      }
    }

    private SceneDto ParseSceneHeading(XElement xmlParagraph, long projectID, long scriptUploadID)
    {
      var sceneNumber = xmlParagraph.Attribute("Number")?.Value;
      var xmlSceneProperties = xmlParagraph.Element("SceneProperties");
      var pageCount = (xmlSceneProperties.Attribute("Length")?.Value).ParsePageLength();

      var sceneHeadingText = xmlParagraph.Element(_textElement).Value;
      var intExtDto = new IntExtDto{ ProjectID = projectID};
      var scriptLocationDto = new ScriptLocationDto{ ProjectID = projectID};
      var dayNightDto = new DayNightDto{ ProjectID = projectID};
      string summary = string.Empty;
      if(sceneHeadingText.HasSeparators(_intExtSeparator, _dayNightSeparator))
      {
        intExtDto.Name = sceneHeadingText.GetSubstringBeforeSeparator(_intExtSeparator);
        scriptLocationDto.Name = sceneHeadingText.GetSubstringBetweenSeparators(_intExtSeparator, _dayNightSeparator);
        dayNightDto.Name = sceneHeadingText.GetSubstringAfterSeparator(_dayNightSeparator);
      }
      else
      {
        summary = sceneHeadingText;
      }

      var sceneDto = new SceneDto
      {
        Number = sceneNumber,
        PageLength = pageCount,
        IntExt = intExtDto,
        ScriptLocation = scriptLocationDto,
        DayNight = dayNightDto,
        Summary = summary,
        ProjectID = projectID
      };

      var sceneId = _sceneService.AddByScriptUpload(sceneDto, scriptUploadID);

      sceneDto.ID = sceneId;
      return sceneDto;
    }

    private ParseCharacterResponse ParseCharacter(XElement xmlParagraph, long currentSceneId, long projectID, long scriptUploadID)
    {
      var characterName = xmlParagraph.Element(_textElement).Value;
      // get character ID
      var characterDto = new CharacterDto();
      var isNewCharacter = false;
      var existingCharacter = _characterRepository.FindBy(c=> c.Name.ToLower() == characterName.ToLower()&& c.ProjectID == projectID);
      if(existingCharacter.Any())
      {
        characterDto = existingCharacter.FirstOrDefault().Translate();
      }
      else
      {
        isNewCharacter = true;
        var character = new Character
        {
            Name = characterName,
            ProjectID = projectID,
            ScriptUploadID = scriptUploadID
        };

        _characterRepository.Add(character);
        _characterRepository.Commit();

        characterDto = new CharacterDto
        {
          ID = character.ID,
          Name = character.Name,
          ProjectID = character.ProjectID
        };
      }

      // verify if character ID linked to current scene
      var existingCharacterScene = _characterSceneRepository.FindBy(cs=> cs.CharacterID == characterDto.ID && cs.SceneID == currentSceneId);
      if(!existingCharacterScene.Any())
      {
        var newCharacterScene = new CharacterScene
        {
          CharacterID = characterDto.ID,
          SceneID = currentSceneId
        };

        _characterSceneRepository.Add(newCharacterScene);
        _characterSceneRepository.Commit();
      }

      return new ParseCharacterResponse
      {
        IsNewCharacter = isNewCharacter,
        Character = characterDto,
      };
    }

    private void ParseDialogue(XElement xmlParagraph, long sceneID, long characterId, int order, long projectID)
    {
      var sb = new StringBuilder();
      foreach(var xmlText in xmlParagraph.Elements(_textElement))
      {
        sb.Append(xmlText.Value);
      }

      var newDialogue = new SceneDialogue
      {
        Text = sb.ToString(),
        Order = order,
        CharacterID = characterId,
        SceneID = sceneID
      };

      _sceneDialogueRepository.Add(newDialogue);
      _sceneDialogueRepository.Commit();
    }

    private void ParseAction(XElement xmlParagraph, long sceneID, int order, long projectID)
    {
      var sb = new StringBuilder();
      foreach(var xmlText in xmlParagraph.Elements(_textElement))
      {
        sb.Append(xmlText.Value);
      }

      var newAction = new SceneAction
      {
        Text = sb.ToString(),
        Order = order,
        SceneID = sceneID
      };

      _sceneActionRepository.Add(newAction);
      _sceneActionRepository.Commit();
    }
  }

  public class ParseCharacterResponse
  {
    public bool IsNewCharacter{ get; set; }

    public CharacterDto Character { get; set; }
  }
}