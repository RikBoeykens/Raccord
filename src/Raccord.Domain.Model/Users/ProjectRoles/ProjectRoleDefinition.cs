using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.Domain.Model.Users.ProjectRoles
{
  public class ProjectRoleDefinition : Entity
  {
    private ICollection<ProjectPermissionRoleDefinition> _permissions;

    /// <summary>
    /// Name of the role
    /// </summary>
    /// <returns></returns>
    public string Name { get; set; }

    /// <summary>
    /// Description of the role
    /// </summary>
    /// <returns></returns>
    public string Description { get; set; }

    /// <summary>
    /// Enum to signify the role
    /// </summary>
    /// <returns></returns>
    public ProjectRoleEnum Role { get; set; }

    /// <summary>
    /// Permissions linked to the role
    /// </summary>
    /// <returns></returns>
    public ICollection<ProjectPermissionRoleDefinition> PermissionRoles
    {
      get
      {
        return _permissions ?? (_permissions = new List<ProjectPermissionRoleDefinition>());
      }
      set
      {
        _permissions = value;
      }
    }
  }
}