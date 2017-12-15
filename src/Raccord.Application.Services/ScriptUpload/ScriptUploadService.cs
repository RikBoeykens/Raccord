using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.ScriptUpload;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Scenes;

namespace Raccord.Application.Services.ScriptUpload
{
  public class ScriptUploadService : IScriptUploadService
  {
    private readonly ICharacterRepository _characterRepository;
    private readonly ICharacterSceneRepository _characterSceneRepository;
    private readonly ISceneService _sceneService;
    private const string _sceneHeadingParagraph = "Scene Heading";
    private const string _characterParagraph = "Character";
    private string _intExtSeparator;
    private string _dayNightSeparator;

    public ScriptUploadService(
      ICharacterRepository characterRepository,
      ICharacterSceneRepository characterSceneRepository,
      ISceneService sceneService
      ){
        _characterRepository = characterRepository;
        _characterSceneRepository = characterSceneRepository;
        _sceneService = sceneService;
      }

    public ScriptUploadResponseDto UploadScript(ScriptUploadRequestDto request)
    {
      XDocument xml = XDocument.Load(request.FileContent);

      var xmlFinalDraft = xml.Element("FinalDraft");

      var xmlSmartType = xmlFinalDraft.Element("SmartType");
      GetSeparators(xmlSmartType);
      return ParseParagraphs(xmlFinalDraft.Element("Content").Elements("Paragraph"), request.ProjectID);
    }

    private void GetSeparators(XElement xmlSmartType)
    {
      _intExtSeparator = xmlSmartType.Element("SceneIntros").Attribute("Separator").Value;

      _dayNightSeparator = xmlSmartType.Element("TimesOfDay").Attribute("Separator").Value;
    }

    public ScriptUploadResponseDto ParseParagraphs(IEnumerable<XElement> xmlParagraphs, long projectID)
    {
      long currentSceneId = default(long);
      foreach(var paragraph in xmlParagraphs)
      {
        switch(paragraph.Attribute("Type").Value)
        {
          case _sceneHeadingParagraph:
            currentSceneId = ParseSceneHeading(paragraph, projectID);
            break;
          case _characterParagraph:
            ParseCharacter(paragraph, currentSceneId, projectID);
            break;
          default:
            break;
        }
      }
      return new ScriptUploadResponseDto
      {
      };
    }

    public long ParseSceneHeading(XElement xmlParagraph, long projectID)
    {
      var sceneNumber = xmlParagraph.Attribute("Number").Value;
      var xmlSceneProperties = xmlParagraph.Element("SceneProperties");
      var pageCount = xmlSceneProperties.Attribute("Length").Value.ParsePageLength();

      var sceneHeadingText = xmlParagraph.Element("Text").Value;
      var intExt = sceneHeadingText.GetSubstringBeforeSeparator(_intExtSeparator);
      var scriptLocation = sceneHeadingText.GetSubstringBetweenSeparators(_intExtSeparator, _dayNightSeparator);
      var dayNight = sceneHeadingText.GetSubstringAfterSeparator(_dayNightSeparator);
      var sceneId = _sceneService.Add(new SceneDto
      {
        Number = sceneNumber,
        PageLength = pageCount,
        IntExt = new IntExtDto { Name = intExt, ProjectID = projectID },
        ScriptLocation = new ScriptLocationDto{ Name = scriptLocation, ProjectID = projectID },
        DayNight = new DayNightDto { Name = dayNight, ProjectID = projectID },
        ProjectID = projectID
      });

      return sceneId;
    }

    public void ParseCharacter(XElement xmlParagraph, long currentSceneId, long projectID)
    {
      var characterName = xmlParagraph.Element("Text").Value;
      // get character ID
      long characterId;
      var existingCharacter = _characterRepository.FindBy(c=> c.Name.ToLower() == characterName.ToLower());
      if(existingCharacter.Any())
      {
        characterId = existingCharacter.FirstOrDefault().ID;
      }
      else
      {
            var character = new Character
            {
                Name = characterName,
                ProjectID = projectID
            };

            _characterRepository.Add(character);
            _characterRepository.Commit();

            characterId = character.ID;
      }

      // verify if character ID linked to current scene
      var existingCharacterScene = _characterSceneRepository.FindBy(cs=> cs.CharacterID == characterId && cs.SceneID == currentSceneId);
      if(!existingCharacterScene.Any())
      {
        var newCharacterScene = new CharacterScene
        {
          CharacterID = characterId,
          SceneID = currentSceneId
        };

        _characterSceneRepository.Add(newCharacterScene);
        _characterSceneRepository.Commit();
      }
    }
  }
}