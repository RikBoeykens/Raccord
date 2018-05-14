using System.Collections.Generic;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Users.ProjectRoles;
using Raccord.Core.Enums;
using System.Linq;

namespace Raccord.Application.Services.Users.ProjectRoles
{
  public static class Utilities
  {
    public static ProjectRoleDto Translate(this ProjectRoleDefinition role)
    {
      if(role == null)
      {
        return null;
      }

      return new ProjectRoleDto
      {
        ID = role.ID,
        Name = role.Name,
        Description = role.Description,
        Role = role.Role,
      };
    }

    public static IEnumerable<ProjectPermissionSummaryDto> GetProjectPermissions(this ApplicationUser user)
    {
      if(user == null)
      {
        return null;
      }

      var projectPermissionsCollection = new List<ProjectPermissionSummaryDto>();
      foreach(var projectUser in user.ProjectUsers)
      {
        var permissions = projectUser.GetProjectPermissions();
        if(permissions!=null)
        {
          projectPermissionsCollection.Add(permissions);
        }
      }
      return projectPermissionsCollection;
    }

    public static ProjectPermissionSummaryDto GetProjectPermissions(this ProjectUser user)
    {
      if(user == null || !user.RoleID.HasValue)
      {
        return null;
      }

      return new ProjectPermissionSummaryDto
      {
        ProjectID = user.ProjectID,
        ProjectPermissions = user.Role.PermissionRoles.Select(pr=> pr.ProjectPermission.Translate())
      };
    }

    public static ProjectPermissionEnum Translate(this ProjectPermissionDefinition projectPermission)
    {
      return projectPermission.Permission;
    }
  }
}