using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.Data.EntityFramework.Repositories.Scenes;

namespace Raccord.Application.Services.ScriptTexts
{
  public class ScriptTextService : IScriptTextService
  {
    private readonly ISceneRepository _sceneRepository;
    
    public ScriptTextService(
      ISceneRepository sceneRepository
    ){
      _sceneRepository = sceneRepository;
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

    public SceneTextDto GetForScene(long sceneID)
    {
      var scene = _sceneRepository.GetScript(sceneID);

      return scene.TranslateScript();
    }
  }
}