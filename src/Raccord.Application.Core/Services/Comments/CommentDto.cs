using System.Collections.Generic;
using Raccord.Application.Core.Services.Profile;

namespace Raccord.Application.Core.Services.Comments
{
  /// <summary>
  /// Info on comment
  /// </summary>
  public class CommentDto : BaseCommentDto
  {
    private UserProfileSummaryDto _user;

    /// <summary>
    /// User who made the comment
    /// </summary>
    /// <returns></returns>
    public UserProfileSummaryDto User
    {
      get
      {
        return _user ?? (_user = new UserProfileSummaryDto());
      }
      set
      {
        _user = value;
      }
    }
  }
}