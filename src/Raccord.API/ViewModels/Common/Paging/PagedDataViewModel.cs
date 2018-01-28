using System.Collections.Generic;

namespace Raccord.API.ViewModels.Common.Paging
{
  public class PagedDataViewModel<T>
  {
    private IEnumerable<T> _data;
    private PageInfoViewModel _pageInfo;

    /// <summary>
    /// Paged data
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> Data
    {
      get
      {
        return _data ?? (_data = new List<T>());
      }
      set
      {
        _data = value;
      }
    }

    /// <summary>
    /// Page info
    /// </summary>
    /// <returns></returns>
    public PageInfoViewModel PageInfo
    {
      get
      {
        return _pageInfo ?? (_pageInfo = new PageInfoViewModel());
      }
      set
      {
        _pageInfo = value;
      }
    }
  }
}