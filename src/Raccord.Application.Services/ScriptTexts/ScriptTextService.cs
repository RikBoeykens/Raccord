using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.Scenes.Actions;
using Raccord.Data.EntityFramework.Repositories.Scenes.Dialogues;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Domain.Model.Scenes.Actions;
using Raccord.Domain.Model.Scenes.Dialogues;

namespace Raccord.Application.Services.ScriptTexts
{
  public class ScriptTextService : IScriptTextService
  {
    private readonly ISceneRepository _sceneRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISceneActionRepository _sceneActionRepository;
    private readonly ISceneDialogueRepository _sceneDialogueRepository;
    
    public ScriptTextService(
      ISceneRepository sceneRepository,
      IUserRepository userRepository,
      ISceneActionRepository sceneActionRepository,
      ISceneDialogueRepository sceneDialogueRepository
    ){
      _sceneRepository = sceneRepository;
      _userRepository = userRepository;
      _sceneActionRepository = sceneActionRepository;
      _sceneDialogueRepository = sceneDialogueRepository;
    }

    public IEnumerable<SceneTextDto> GetForProject(long projectID)
    {
      var scenes = _sceneRepository.GetScriptForProject(projectID);

      return scenes.Select(s=> s.TranslateScript());
    }

    public IEnumerable<SceneTextDto> GetForCallsheet(long callsheetID)
    {
      var scenes = _sceneRepository.GetScriptForCallsheet(callsheetID);

      return scenes.Select(s=> s.TranslateScript());
    }

    public IEnumerable<SceneTextDto> GetForUser(long projectID, string userID)
    {
      var user = _userRepository.GetFull(userID);
      var characterIds = user.ProjectUsers.Where(pu => pu.ProjectID == projectID)
                                          .SelectMany(pu => pu.CastMember.Characters.Select(c => c.ID)).ToArray();
      var scenes = _sceneRepository.GetScriptForCharacters(characterIds);

      return scenes.Select(s=> s.TranslateScript());
    }

    public SceneTextDto GetForScene(long sceneID)
    {
      var scene = _sceneRepository.GetScript(sceneID);

      return scene.TranslateScript();
    }

    public void AddScriptTexts(long sceneId, IEnumerable<SceneActionDto> actionDtos, IEnumerable<SceneDialogueDto> dialogueDtos)
    {
      foreach(var action in actionDtos)
      {
        _sceneActionRepository.Add(new SceneAction
        {
          Text = action.Text,
          Order = action.Order,
          SceneID = sceneId
        });
      }
      _sceneActionRepository.Commit();
      
      foreach(var dialogue in dialogueDtos)
      {
        _sceneDialogueRepository.Add(new SceneDialogue
        {
          Text = dialogue.Text,
          Order = dialogue.Order,
          CharacterID = dialogue.Character.ID,
          SceneID = sceneId
        });
      }
      _sceneDialogueRepository.Commit();
    }
  }
}