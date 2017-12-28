using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;
using Raccord.Domain.Model.Callsheets.Scenes;

namespace Raccord.Application.Services.Breakdowns.BreakdownItemScenes
{
  public static class Utilities
  {
    public static CallsheetBreakdownItemSceneDto TranslateCallsheet(this CallsheetScene callsheetScene, IEnumerable<CallsheetBreakdownItemDto> breakdownItems)
    {
      if(callsheetScene == null || callsheetScene.Scene == null)
      {
        return null;
      }

      return new CallsheetBreakdownItemSceneDto
      {
        SceneID = callsheetScene.SceneID,
        SceneNumber = callsheetScene.Scene.Number,
        Items = breakdownItems
      };
    }
  }
}