namespace Raccord.Application.Core.Common.Paging
{
  public class PaginationRequestDto
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
    /// Return full
    /// </summary>
    /// <returns></returns>
    public bool Full { get; set; }
  }
}