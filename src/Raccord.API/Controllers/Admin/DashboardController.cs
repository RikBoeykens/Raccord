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
using Raccord.API.ViewModels.Common.Paging;

namespace Raccord.API.Controllers.Admin
{
    public class DashboardController : AbstractAdminController
    {
        private readonly IProjectService _projectService;

        public DashboardController(IProjectService projectService)
        {
            if (projectService == null)
                throw new ArgumentNullException(nameof(projectService));

            _projectService = projectService;
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public AdminDashboardViewModel Get()
        {
            var paginatedProjects = _projectService.GetAdminPaged(new PaginationRequestDto
            {
                Page = 1,
                PageSize = 4
            });

            var projectVms = paginatedProjects.Translate<AdminProjectSummaryViewModel, AdminProjectSummaryDto>(ProjectUtilities.Translate);

            return new AdminDashboardViewModel
            {
                Projects = projectVms
            };
        }
    }
}
