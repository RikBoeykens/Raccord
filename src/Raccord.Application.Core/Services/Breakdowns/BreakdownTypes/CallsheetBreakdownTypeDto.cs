using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownTypes
{
    // Dto to represent a breakdown type on a callsheet
    public class CallsheetBreakdownTypeDto : BreakdownTypeDto
    {
      private IEnumerable<CallsheetBreakdownItemSceneDto> _scenes;
      
      /// <summary>
      /// Scenes on a breakdown type
      /// </summary>
      /// <returns></returns>
      public IEnumerable<CallsheetBreakdownItemSceneDto> Scenes
      {
        get
        {
          return _scenes ?? (_scenes = new List<CallsheetBreakdownItemSceneDto>());
        }
        set
        {
          _scenes = value;
        }
      }
    }
}