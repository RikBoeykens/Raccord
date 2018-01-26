using System.Collections.Generic;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
  // Dto to represent a search request for a breakdown item
  public class SearchBreakdownItemRequestViewModel
  {
    private IEnumerable<long> _excludeIds;
    
    public string SearchText { get; set; }

    public long TypeID { get; set; }

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