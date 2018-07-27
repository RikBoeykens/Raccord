using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ScriptTexts
{
  public interface IScriptTextService
  {
    IEnumerable<SceneTextDto> GetForProject(long projectID);
    IEnumerable<SceneTextDto> GetForCallsheet(long callsheetID);
    IEnumerable<SceneTextDto> GetForUser(long projectID, string userID);
    SceneTextDto GetForScene(long sceneID);
    void AddScriptTexts(long sceneId, IEnumerable<SceneActionDto> actions, IEnumerable<SceneDialogueDto> dialogues);
  }
}