using System.Collections.Generic;
using Raccord.Application.Core.Services.Profile;

namespace Raccord.Application.Core.Services.Comments
{
  /// <summary>
  /// Info on comment
  /// </summary>
  public class BaseCommentDto
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