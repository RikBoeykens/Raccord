using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Microsoft.AspNetCore.Authorization;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectRolesController : AbstractAdminController
    {
        private readonly IProjectRoleService _projectRoleService;

        public ProjectRolesController(IProjectRoleService projectService)
        {
            if (projectService == null)
                throw new ArgumentNullException(nameof(projectService));

            _projectRoleService = projectService;
        }

        // GET: api/projectroles
        [HttpGet]
        public IEnumerable<ProjectRoleViewModel> Get()
        {
            var projectDtos = _projectRoleService.GetRoles();

            var projectVms = projectDtos.Select(p => p.Translate());

            return projectVms;
        }
    }
}
