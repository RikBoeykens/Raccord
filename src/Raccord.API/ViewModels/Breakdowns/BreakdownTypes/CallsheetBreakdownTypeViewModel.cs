using System.Collections.Generic;
using System.Linq;
using Raccord.API.ViewModels.Breakdowns.BreakdownItemScenes;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownTypes
{
    // Dto to represent a breakdown type on a callsheet
    public class CallsheetBreakdownTypeViewModel : BreakdownTypeViewModel
    {
      private IEnumerable<CallsheetBreakdownItemSceneViewModel> _scenes;
      
      /// <summary>
      /// Scenes on a breakdown type
      /// </summary>
      /// <returns></returns>
      public IEnumerable<CallsheetBreakdownItemSceneViewModel> Scenes
      {
        get
        {
          return _scenes ?? (_scenes = new List<CallsheetBreakdownItemSceneViewModel>());
        }
        set
        {
          _scenes = value;
        }
      }
    }
}