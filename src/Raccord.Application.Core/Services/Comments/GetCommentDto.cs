using System.Collections.Generic;
using Raccord.Application.Core.Services.Profile;
using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.Comments
{
  /// <summary>
  /// Info on comment
  /// </summary>
  public class GetCommentDto
  {
    public long ParentID { get; set; }
    public ParentCommentType ParentType { get; set; }
  }
}