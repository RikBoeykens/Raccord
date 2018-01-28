namespace Raccord.API.ViewModels.Common.Paging
{
  public class PageInfoViewModel
  {
    /// <summary>
    /// Page
    /// </summary>
    /// <returns></returns>
    public int Page { get; set; }

    /// <summary>
    /// Pagesize
    /// </summary>
    /// <returns></returns>
    public int PageSize { get; set; }

    /// <summary>
    /// Total elements
    /// </summary>
    /// <returns></returns>
    public int Total { get; set; }

    /// <summary>
    /// Indicates if the full data is returned
    /// </summary>
    /// <returns></returns>
    public bool Full { get; set; }
  }
}