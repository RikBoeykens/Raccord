using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Users.ProjectRoles
{
  public interface IProjectPermissionService
  {
      IEnumerable<ProjectPermissionSummaryDto> GetProjectPermissions(string userID);
  }
}