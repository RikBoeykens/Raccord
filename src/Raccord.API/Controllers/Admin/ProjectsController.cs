using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Projects;
using Microsoft.AspNetCore.Authorization;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectsController : AbstractAdminController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            if (projectService == null)
                throw new ArgumentNullException(nameof(projectService));

            _projectService = projectService;
        }

        // GET: api/projects
        [HttpGet]
        public IEnumerable<AdminProjectSummaryViewModel> Get()
        {
            var projectDtos = _projectService.GetAdminPaged(new PaginationRequestDto
            {
                Full = true
            });

            var projectVms = projectDtos.Data.Select(p => p.Translate());

            return projectVms;
        }
        // GET api/projects/5
        [HttpGet("{id}")]
        public AdminFullProjectViewModel Get(long id)
        {
            var projectDto = _projectService.GetForAdmin(id);

            var projectVm = projectDto.Translate();

            return projectVm;
        }

        // GET api/projects/5
        [HttpGet("{id}/summary")]
        public ProjectSummaryViewModel GetSummary(long id)
        {
            var projectDto = _projectService.GetSummary(id);

            var projectVm = projectDto.Translate();

            return projectVm;
        }

        // POST api/projects
        [HttpPost]
        public JsonResult Post([FromBody]ProjectViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var projectDto = vm.Translate();

                Int64 projectID;

                if (projectDto.ID == default(long))
                {
                    projectID = _projectService.Add(projectDto);
                }
                else
                {
                    projectID = _projectService.Update(projectDto);
                }

                response = new JsonResponse
                {
                    ok = true,
                    data = projectID,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to update project",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/projects/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _projectService.Delete(id);

                response = new JsonResponse
                {
                    ok = true,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to delete project.",
                };
            }

            return new JsonResult(response);
        }
    }
}
