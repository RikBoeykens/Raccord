using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.Users;

namespace Raccord.Application.Services.ScriptTexts
{
  public class ScriptTextService : IScriptTextService
  {
    private readonly ISceneRepository _sceneRepository;
        private readonly IUserRepository _userRepository;
    
    public ScriptTextService(
      ISceneRepository sceneRepository,
      IUserRepository userRepository
    ){
      _sceneRepository = sceneRepository;
      _userRepository = userRepository;
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
  }
}