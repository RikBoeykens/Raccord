using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Application.Services.Users.ProjectRoles;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Application.Services.User.ProjectRoles
{
  public class ProjectPermissionService : IProjectPermissionService
  {
    private readonly IUserRepository _userRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProjectUserRepository _projectUserRepository;

    public ProjectPermissionService(
      IUserRepository userRepository,
      UserManager<ApplicationUser> userManager,
      IHttpContextAccessor httpContextAccessor,
      IProjectUserRepository projectUserRepository
    )
    {
      _userRepository = userRepository;
      _userManager = userManager;
      _httpContextAccessor = httpContextAccessor;
      _projectUserRepository = projectUserRepository;
    }

    public IEnumerable<ProjectPermissionSummaryDto> GetProjectPermissions(string userID)
    {
      var user = _userRepository.GetForPermissions(userID);

      return user.GetProjectPermissions();
    }

    public bool HasPermission(long projectID, ProjectPermissionEnum permission)
    {
      var userID = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

      var projectUser = _projectUserRepository.GetForPermissions(projectID, userID);

      return projectUser.RoleID.HasValue ? projectUser.Role.PermissionRoles.Any(pr=> pr.ProjectPermission.Permission == permission) : false;
    }
  }
}