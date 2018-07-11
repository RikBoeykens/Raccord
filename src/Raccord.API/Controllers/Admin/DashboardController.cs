using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Projects;
using Microsoft.AspNetCore.Authorization;
using Raccord.API.ViewModels.Dashboards.Admin;
using Raccord.Application.Core.Common.Paging;
using PaginationUtilities = Raccord.API.ViewModels.Common.Paging.Utilities;
using ProjectUtilities = Raccord.API.ViewModels.Projects.Utilities;
using UserUtilities = Raccord.API.ViewModels.Users.Utilities;
using InvitationUtilities = Raccord.API.ViewModels.Users.Invitations.Utilities;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Users.Invitations;

namespace Raccord.API.Controllers.Admin
{
    public class DashboardController : AbstractAdminController
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IUserInvitationService _userInvitationService;
        private readonly int _defaultPageSize = 4;

        public DashboardController(
            IProjectService projectService,
            IUserService userService,
            IUserInvitationService userInvitationService
            )
        {
            _projectService = projectService;
            _userService = userService;
            _userInvitationService = userInvitationService;
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public AdminDashboardViewModel Get()
        {
            var projects = GetProjects();
            var users = GetUsers();
            var invitations = GetUserInvitations();
            return new AdminDashboardViewModel
            {
                Projects = projects,
                Users = users,
                Invitations = invitations
            };
        }

        private PagedDataViewModel<AdminProjectSummaryViewModel> GetProjects()
        {
            var paginatedProjects = _projectService.GetAdminPaged(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedProjects.Translate<AdminProjectSummaryViewModel, AdminProjectSummaryDto>(ProjectUtilities.Translate);
        }

        private PagedDataViewModel<AdminUserSummaryViewModel> GetUsers()
        {
            var paginatedUsers = _userService.GetAdminPaged(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedUsers.Translate<AdminUserSummaryViewModel, AdminUserSummaryDto>(UserUtilities.Translate);
        }

        private PagedDataViewModel<AdminUserInvitationSummaryViewModel> GetUserInvitations()
        {
            var paginatedUserInvitations = _userInvitationService.GetAdminPaged(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedUserInvitations.Translate<AdminUserInvitationSummaryViewModel, AdminUserInvitationSummaryDto>(InvitationUtilities.Translate);
        }
    }
}
