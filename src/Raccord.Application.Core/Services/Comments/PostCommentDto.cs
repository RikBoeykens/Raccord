using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.Comments
{
  /// <summary>
  /// Info to post comment
  /// </summary>
  public class PostCommentDto : BaseCommentDto
  {
    /// <summary>
    /// ID of the user linked to the comment
    /// </summary>
    /// <returns></returns>
    public string UserID { get; set; }
    public long ParentID { get; set; }
    public ParentCommentType ParentType { get; set; }
  }
}