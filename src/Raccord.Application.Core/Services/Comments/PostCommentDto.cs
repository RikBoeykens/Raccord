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

    /// <summary>
    /// ID of the parent project (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ProjectID { get; set; }

    /// <summary>
    /// ID of the parent comment (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? CommentID { get; set; }
  }
}