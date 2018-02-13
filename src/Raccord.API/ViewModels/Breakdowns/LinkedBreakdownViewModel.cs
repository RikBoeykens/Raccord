using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns
{
  public class LinkedBreakdownViewModel : BaseBreakdownViewModel
  {
    private IEnumerable<LinkedBreakdownItemViewModel> _items;
    private IEnumerable<BreakdownTypeViewModel> _types;

    public string UserID { get; set; }

    public IEnumerable<LinkedBreakdownItemViewModel> Items
    {
      get
      {
        return _items ?? (_items = new List<LinkedBreakdownItemViewModel>());
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