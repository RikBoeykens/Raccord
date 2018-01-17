using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.Users.ProjectRoles
{
  public interface IProjectPermissionService
  {
      IEnumerable<ProjectPermissionSummaryDto> GetProjectPermissions(string userID);
      bool HasPermission(long projectId, ProjectPermissionEnum permission);
  }
}