using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ScriptTexts
{
  public interface IScriptTextService
  {
    IEnumerable<SceneTextDto> GetForProject(long projectID);
    IEnumerable<SceneTextDto> GetForCallsheet(long callsheetID);
    SceneTextDto GetForScene(long sceneID);
  }
}