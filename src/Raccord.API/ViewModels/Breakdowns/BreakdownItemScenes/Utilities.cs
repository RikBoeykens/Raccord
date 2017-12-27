using System.Linq;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItemScenes
{
  public static class Utilities
  {
    public static CallsheetBreakdownItemSceneViewModel Translate(this CallsheetBreakdownItemSceneDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new CallsheetBreakdownItemSceneViewModel
      {
        SceneID = dto.SceneID,
        SceneNumber = dto.SceneNumber,
        Items = dto.Items.Select(i => i.Translate()),
      };
    }
  }
}