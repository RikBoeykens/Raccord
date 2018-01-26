namespace Raccord.Application.Core.Common.Paging
{
  public class PageInfoDto
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