using System.Linq;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.ProjectRoles
{
  public static class Utilities
  {
    public static ProjectRoleViewModel Translate(this ProjectRoleDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new ProjectRoleViewModel
      {
        ID = dto.ID,
        Role = dto.Role,
        Name = dto.Name,
        Description = dto.Description
      };
    }

    public static ProjectPermissionSummaryViewModel Translate(this ProjectPermissionSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new ProjectPermissionSummaryViewModel
      {
        ProjectID = dto.ProjectID,
        ProjectPermissions = dto.ProjectPermissions
      };
    }
  }
}