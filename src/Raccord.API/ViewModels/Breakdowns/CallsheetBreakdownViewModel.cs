using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns
{
  public class CallsheetBreakdownViewModel : BaseBreakdownViewModel
  {
    private IEnumerable<CallsheetBreakdownTypeViewModel> _types;


    public IEnumerable<CallsheetBreakdownTypeViewModel> Types
    {
      get
      {
        return _types ?? (_types = new List<CallsheetBreakdownTypeViewModel>());
      }
      set
      {
        _types = value;
      }
    }
  }
}