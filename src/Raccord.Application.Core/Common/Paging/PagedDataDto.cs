using System.Collections.Generic;

namespace Raccord.Application.Core.Common.Paging
{
  public class PagedDataDto<T>
  {
    private IEnumerable<T> _data;
    private PageInfoDto _pageInfo;

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
    public PageInfoDto PageInfo
    {
      get
      {
        return _pageInfo ?? (_pageInfo = new PageInfoDto());
      }
      set
      {
        _pageInfo = value;
      }
    }
  }
}