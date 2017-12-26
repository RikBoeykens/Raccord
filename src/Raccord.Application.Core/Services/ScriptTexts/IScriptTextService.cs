using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ScriptTexts
{
  public interface IScriptTextService
  {
    IEnumerable<SceneTextDto> GetForProject(long projectID);
    SceneTextDto GetForScene(long sceneID);
  }
}