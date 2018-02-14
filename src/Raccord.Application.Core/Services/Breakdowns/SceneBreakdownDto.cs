using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Core.Services.Breakdowns
{
  public class SceneBreakdownDto : BaseBreakdownDto
  {
    private IEnumerable<SceneBreakdownItemDto> _items;
    private IEnumerable<BreakdownTypeDto> _types;
    public string UserID { get; set; }

    public IEnumerable<SceneBreakdownItemDto> Items
    {
      get
      {
        return _items ?? (_items = new List<SceneBreakdownItemDto>());
      }
      set
      {
        _items = value;
      }
    }

    public IEnumerable<BreakdownTypeDto> Types
    {
      get
      {
        return _types ?? (_types = new List<BreakdownTypeDto>());
      }
      set
      {
        _types = value;
      }
    }
  }
}