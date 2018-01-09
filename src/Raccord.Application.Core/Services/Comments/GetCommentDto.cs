using System.Collections.Generic;
using Raccord.Application.Core.Services.Profile;

namespace Raccord.Application.Core.Services.Comments
{
  /// <summary>
  /// Info on comment
  /// </summary>
  public class GetCommentDto
  {
    /// <summary>
    /// ID of the linked project
    /// </summary>
    /// <returns></returns>
    public long? ProjectID { get; set; }

    /// <summary>
    /// ID of the linked comment
    /// </summary>
    /// <returns></returns>
    public long? CommentID { get; set; }
  }
}