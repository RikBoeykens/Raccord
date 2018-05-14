using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Users.ProjectRoles
{
  public interface IProjectRoleService
  {
      IEnumerable<ProjectRoleDto> GetRoles();
  }
}