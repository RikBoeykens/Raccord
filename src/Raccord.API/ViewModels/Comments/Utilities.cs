using System.Linq;
using Raccord.API.ViewModels.Profile;
using Raccord.Application.Core.Services.Comments;

namespace Raccord.API.ViewModels.Comments
{
  public static class Utilities
  {
    public static CommentViewModel Translate(this CommentDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new CommentViewModel
      {
        ID = dto.ID,
        Text = dto.Text,
        User = dto.User.Translate(),
        Comments = dto.Comments.Select(c => c.Translate())
      };
    }

    public static PostCommentDto Translate(this PostCommentViewModel vm, string userID)
    {
      if(vm == null)
      {
        return null;
      }

      return new PostCommentDto
      {
        ID = vm.ID,
        Text = vm.Text,
        ParentID = vm.ParentID,
        ParentType = vm.ParentType,
        UserID = userID
      };
    }
  }
}