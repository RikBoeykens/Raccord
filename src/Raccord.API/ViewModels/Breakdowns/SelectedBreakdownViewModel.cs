using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns
{
  public class SelectedBreakdownViewModel: BaseBreakdownViewModel
  {
    private IEnumerable<BreakdownTypeSummaryViewModel> _types;
    public IEnumerable<BreakdownTypeSummaryViewModel> Types
    {
      get
      {
        return _types ?? (_types = new List<BreakdownTypeSummaryViewModel>());
      }
      set
      {
        _types = value;
      }
    }
  }
}