using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Comments
{
  public class PostCommentViewModel : BaseCommentViewModel
  {
    public long ParentID { get; set; }
    public ParentCommentType ParentType { get; set; }
  }
}