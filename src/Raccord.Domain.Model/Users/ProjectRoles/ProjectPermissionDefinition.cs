using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.Domain.Model.Users.ProjectRoles
{
  public class ProjectPermissionDefinition : Entity
  {
    private ICollection<ProjectPermissionRoleDefinition> _roles;

    /// <summary>
    /// Name of the permission
    /// </summary>
    /// <returns></returns>
    public string Name { get; set; }

    /// <summary>
    /// Description of the permission
    /// </summary>
    /// <returns></returns>
    public string Description { get; set; }

    /// <summary>
    /// Enum to signify the role
    /// </summary>
    /// <returns></returns>
    public ProjectPermissionEnum Permission { get; set; }

    /// <summary>
    /// Permissions linked to the role
    /// </summary>
    /// <returns></returns>
    public ICollection<ProjectPermissionRoleDefinition> PermissionRoles
    {
      get
      {
        return _roles ?? (_roles = new List<ProjectPermissionRoleDefinition>());
      }
      set
      {
        _roles = value;
      }
    }
  }
}