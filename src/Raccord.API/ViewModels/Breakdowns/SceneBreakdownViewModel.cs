using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns
{
  public class SceneBreakdownViewModel : BaseBreakdownViewModel
  {
    private IEnumerable<SceneBreakdownItemViewModel> _items;
    private IEnumerable<BreakdownTypeViewModel> _types;

    public string UserID { get; set; }

    public IEnumerable<SceneBreakdownItemViewModel> Items
    {
      get
      {
        return _items ?? (_items = new List<SceneBreakdownItemViewModel>());
      }
      set
      {
        _items = value;
      }
    }

    public IEnumerable<BreakdownTypeViewModel> Types
    {
      get
      {
        return _types ?? (_types = new List<BreakdownTypeViewModel>());
      }
      set
      {
        _types = value;
      }
    }
  }
}