using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
  // Dto to represent a search request for a breakdown item
  public class SearchBreakdownItemRequestDto
  {
    private IEnumerable<long> _excludeIds;
    
    public string SearchText { get; set; }

    public long TypeID { get; set; }

    public string UserID { get; set; }

    public bool IsAdmin { get; set; }

    public IEnumerable<long> ExcludeIDs 
    {
      get
      {
        return _excludeIds ?? (_excludeIds = new List<long>());
      }
      set
      {
        _excludeIds = value;
      }
    }    
  }
}