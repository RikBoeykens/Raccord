using System.Collections.Generic;
using System.Linq;
using Raccord.API.ViewModels.Profile;

namespace Raccord.API.ViewModels.Comments
{
  public class CommentViewModel : BaseCommentViewModel
  {
    private UserProfileSummaryViewModel _user;
    private IEnumerable<CommentViewModel> _comments;

    /// <summary>
    /// User who made the comment
    /// </summary>
    /// <returns></returns>
    public UserProfileSummaryViewModel User
    {
      get
      {
        return _user ?? (_user = new UserProfileSummaryViewModel());
      }
      set
      {
        _user = value;
      }
    }

    public IEnumerable<CommentViewModel> Comments
    {
      get
      {
        return _comments ?? (_comments = new List<CommentViewModel>());
      }
      set
      {
        _comments = value;
      }
    }

    public int CommentCount
    {
      get
      {
        return _comments.Sum(c => c.CommentCount) + 1;
      }
    }
  }
}