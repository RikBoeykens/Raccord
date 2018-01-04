namespace Raccord.API.ViewModels.Comments
{
  public class PostCommentViewModel : BaseCommentViewModel
  {
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