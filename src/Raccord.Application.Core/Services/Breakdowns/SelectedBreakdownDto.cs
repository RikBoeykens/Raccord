using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Core.Services.Breakdowns
{
  public class SelectedBreakdownDto: BreakdownDto
  {
    private IEnumerable<BreakdownTypeSummaryDto> _types;
    public IEnumerable<BreakdownTypeSummaryDto> Types
    {
      get
      {
        return _types ?? (_types = new List<BreakdownTypeSummaryDto>());
      }
      set
      {
        _types = value;
      }
    }
  }
}