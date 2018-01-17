using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Application.Services.Users.ProjectRoles;
using Raccord.Data.EntityFramework.Repositories.Users.ProjectRoles;

namespace Raccord.Application.Services.User.ProjectRoles
{
  public class ProjectRoleService : IProjectRoleService
  {
    private readonly IProjectRoleDefinitionRepository _projectRoleRepository;

    public ProjectRoleService(
      IProjectRoleDefinitionRepository projectRoleRepository
    )
    {
      _projectRoleRepository = projectRoleRepository;
    }

    public IEnumerable<ProjectRoleDto> GetRoles()
    {
      var roles = _projectRoleRepository.GetAll();

      return roles.Select(r=> r.Translate());
    }
  }
}