using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes
{
  public class CallsheetBreakdownItemSceneDto
  {
    private IEnumerable<CallsheetBreakdownItemDto> _items;

    /// <summary>
    /// ID of the scene
    /// </summary>
    /// <returns></returns>
    public long SceneID { get; set; }

    /// <summary>
    /// Number of the scene
    /// </summary>
    /// <returns></returns>
    public string SceneNumber { get; set; }

    /// <summary>
    /// Breakdown items for a scene
    /// </summary>
    /// <returns></returns>
    public IEnumerable<CallsheetBreakdownItemDto> Items
    {
      get
      {
        return _items ?? (_items = new List<CallsheetBreakdownItemDto>());
      }
      set
      {
        _items = value;
      }
    }
  }
}