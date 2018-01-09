using System.Linq;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Services.Profile;
using Raccord.Domain.Model.Comments;

namespace Raccord.Application.Services.Comments
{
  public static class Utilities
  {
    public static CommentDto Translate(this Comment comment)
    {
      if(comment == null)
      {
        return null;
      }

      return new CommentDto
      {
        ID = comment.ID,
        Text = comment.Text,
        User = comment.User.TranslateSummary()
      };
    }
  }
}