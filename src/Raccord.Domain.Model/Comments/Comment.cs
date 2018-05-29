using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Locations.Locations;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.Shots;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Comments
{
  /// <summary>
  /// Comment on a project/scene/.../comment
  /// </summary>
  public class Comment: Entity<long>
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
    /// ID of the scene the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentSceneID { get; set; }

    /// <summary>
    /// Scene the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Scene ParentScene { get; set; }

    /// <summary>
    /// ID of the breakdown item the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentCharacterID { get; set; }

    /// <summary>
    /// Breakdown item the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Character ParentCharacter { get; set; }

    /// <summary>
    /// ID of the breakdown item the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentBreakdownItemID { get; set; }

    /// <summary>
    /// Breakdown item the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual BreakdownItem ParentBreakdownItem { get; set; }

    /// <summary>
    /// ID of the image the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentImageID { get; set; }

    /// <summary>
    /// Image the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Image ParentImage { get; set; }

    /// <summary>
    /// ID of the location the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentLocationID { get; set; }

    /// <summary>
    /// Location the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Location ParentLocation { get; set; }

    /// <summary>
    /// ID of the script location the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentScriptLocationID { get; set; }

    /// <summary>
    /// Script location the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual ScriptLocation ParentScriptLocation { get; set; }

    /// <summary>
    /// ID of the slate the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentSlateID { get; set; }

    /// <summary>
    /// Slate the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Slate ParentSlate { get; set; }

    /// <summary>
    /// ID of the take the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public long? ParentTakeID { get; set; }

    /// <summary>
    /// Take the comment is linked to (if applicable)
    /// </summary>
    /// <returns></returns>
    public virtual Take ParentTake { get; set; }

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