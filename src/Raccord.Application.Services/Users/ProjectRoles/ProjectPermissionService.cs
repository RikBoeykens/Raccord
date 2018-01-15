using System.Collections.Generic;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Application.Services.Users.ProjectRoles;
using Raccord.Data.EntityFramework.Repositories.Users;

namespace Raccord.Application.Services.User.ProjectRoles
{
  public class ProjectPermissionService : IProjectPermissionService
  {
    private readonly IUserRepository _userRepository;

    public ProjectPermissionService(
      IUserRepository userRepository
    )
    {
      _userRepository = userRepository;
    }

    public IEnumerable<ProjectPermissionSummaryDto> GetProjectPermissions(string userID)
    {
      var user = _userRepository.GetForPermissions(userID);

      return user.GetProjectPermissions();
    }
  }
}