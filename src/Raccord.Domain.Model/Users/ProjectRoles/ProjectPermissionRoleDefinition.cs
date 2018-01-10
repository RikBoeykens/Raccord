using Raccord.Core.Enums;

namespace Raccord.Domain.Model.Users.ProjectRoles
{
  public class ProjectPermissionRoleDefinition : Entity
  {
    /// <summary>
    /// ID of the linked role
    /// </summary>
    /// <returns></returns>
    public long RoleID { get; set; }

    /// <summary>
    /// Linked role
    /// </summary>
    /// <returns></returns>
    public virtual ProjectRoleDefinition ProjectRole { get; set; }

    /// <summary>
    /// ID of the linked permission
    /// </summary>
    /// <returns></returns>
    public long PermissionID { get; set; }

    /// <summary>
    /// Linked Permission
    /// </summary>
    /// <returns></returns>
    public virtual ProjectPermissionDefinition ProjectPermission { get; set; }
  }
}