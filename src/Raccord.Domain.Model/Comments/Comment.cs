using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Comments
{
  /// <summary>
  /// Comment on a project/scene/.../comment
  /// </summary>
  public class Comment: Entity
  {
    private ICollection<Comment> _comments;

    /// <summary>
    /// Text of the comment
    /// </summary>
    /// <returns></returns>
    public string Text { get; set; }

    /// <summary>
    /// ID of the user making the comment
    /// </summary>
    /// <returns></returns>
    public string UserID { get; set; }

    /// <summary>
    /// User making the comment
    /// </summary>
    /// <returns></returns>
    public virtual ApplicationUser User { get; set; }

    /// <summary>
    /// ID of the project the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentProjectID { get; set; }

    /// <summary>
    /// Project the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Project ParentProject { get; set; }

    /// <summary>
    /// ID of the comment the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentCommentID { get; set; }

    /// <summary>
    /// Comment the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Comment ParentComment { get; set; }

    /// <summary>
    /// Comments replied to the comment
    /// </summary>
    /// <returns></returns>
    public virtual ICollection<Comment> Comments
    {
      get
      {
        return _comments ?? (_comments = new List<Comment>());
      }
      set
      {
        _comments = value;
      }
    }
  }
}