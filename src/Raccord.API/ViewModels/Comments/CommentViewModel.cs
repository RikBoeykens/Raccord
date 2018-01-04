using System.Collections.Generic;
using Raccord.API.ViewModels.Profile;

namespace Raccord.API.ViewModels.Comments
{
  public class CommentViewModel : BaseCommentViewModel
  {
    private IEnumerable<CommentViewModel> _comments;
    private UserProfileViewModel _user;

    /// <summary>
    /// Comments linked to the comment
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// User who made the comment
    /// </summary>
    /// <returns></returns>
    public UserProfileViewModel User
    {
      get
      {
        return _user ?? (_user = new UserProfileViewModel());
      }
      set
      {
        _user = value;
      }
    }
  }
}