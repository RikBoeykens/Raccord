using System.Collections.Generic;
using Raccord.API.ViewModels.Profile;

namespace Raccord.API.ViewModels.Comments
{
  public class CommentViewModel : BaseCommentViewModel
  {
    private UserProfileSummaryViewModel _user;

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
  }
}