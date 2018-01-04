namespace Raccord.API.ViewModels.Comments
{
  public class BaseCommentViewModel
  {
    /// <summary>
    /// ID of the comment
    /// </summary>
    /// <returns></returns>
    public long ID { get; set; }

    /// <summary>
    /// Text of the comment
    /// </summary>
    /// <returns></returns>
    public string Text { get; set; }
  }
}