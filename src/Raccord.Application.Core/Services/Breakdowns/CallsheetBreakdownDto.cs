using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Core.Services.Breakdowns
{
  public class CallsheetBreakdownDto : BaseBreakdownDto
  {
    private IEnumerable<CallsheetBreakdownTypeDto> _types;


    public IEnumerable<CallsheetBreakdownTypeDto> Types
    {
      get
      {
        return _types ?? (_types = new List<CallsheetBreakdownTypeDto>());
      }
      set
      {
        _types = value;
      }
    }
  }
}