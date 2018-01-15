using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Account;
using Raccord.API.ViewModels.Users.ProjectRoles;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class AccountController : AbstractApiAuthController
    {
        private readonly IProjectPermissionService _permissionService;
        public AccountController(
            IProjectPermissionService permissionService,
            UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _permissionService = permissionService;
        }

        // GET: api/account/permissions
        [HttpGet("permissions")]
        public UserPermissionSummaryViewModel GetPermissions()
        {
            var isAdmin = this.User.IsInRole("admin");
            var projectPermissions = _permissionService.GetProjectPermissions(GetUserId());

            return new UserPermissionSummaryViewModel
            {
                IsAdmin = isAdmin,
                ProjectPermissions = projectPermissions.Select(pp=> pp.Translate()),
            };
        }
    }
}