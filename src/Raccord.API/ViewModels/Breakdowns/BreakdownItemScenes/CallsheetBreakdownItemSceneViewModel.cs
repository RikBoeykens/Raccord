using System.Collections.Generic;
using System.Linq;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItemScenes
{
  public class CallsheetBreakdownItemSceneViewModel
  {
    private IEnumerable<CallsheetBreakdownItemViewModel> _items;

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
    public IEnumerable<CallsheetBreakdownItemViewModel> Items
    {
      get
      {
        return _items ?? (_items = new List<CallsheetBreakdownItemViewModel>());
      }
      set
      {
        _items = value;
      }
    }
  }
}