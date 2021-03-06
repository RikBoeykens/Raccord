using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.Application.Core.Common.Paging;
using PaginationUtilities = Raccord.API.ViewModels.Common.Paging.Utilities;
using ProjectUtilities = Raccord.API.ViewModels.Projects.Utilities;
using Raccord.API.ViewModels.Common.Paging;

namespace Raccord.API.Controllers
{
    public class ProjectsController : AbstractApiAuthController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(
            IProjectService projectService,
            UserManager<ApplicationUser> userManager
            ):base(userManager)
        {
            if (projectService == null)
                throw new ArgumentNullException(nameof(projectService));

            _projectService = projectService;
        }

        // GET: api/projects
        [HttpGet]
        public IEnumerable<UserProjectViewModel> Get()
        {
            var projectDtos = _projectService.GetFullForUser(GetUserId());

            var projectVms = projectDtos.Select(p => p.Translate());

            return projectVms;
        }

        // GET: api/projects/summary
        [HttpGet("summary")]
        public IEnumerable<UserProjectSummaryViewModel> GetSummaries()
        {
            var projectDtos = _projectService.GetAllForUser(GetUserId());

            var projectVms = projectDtos.Select(p => p.Translate());

            return projectVms;
        }

        // GET: api/projects/paged
        [HttpGet("paged")]
        public JsonResult GetSummariesPaged([FromQuery]int? pageSize = null, [FromQuery]int? page = null, [FromQuery]bool full = true)
        {
            var response = new JsonResponse();

            try
            {
                var paginationRequest = PaginationUtilities.ConstructRequest(pageSize, page, full);
                var paginationResult = _projectService.GetAllForUserPaged(GetUserId(), paginationRequest);

                response = new JsonResponse
                {
                    ok = true,
                    data = paginationResult.Translate<UserProjectViewModel, UserProjectDto>(ProjectUtilities.Translate),
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while trying to get search results.",
                };
            }

            return new JsonResult(response);
        }

        // GET api/projects/5
        [HttpGet("{id}")]
        public FullProjectViewModel Get(long id)
        {
            var projectDto = _projectService.Get(id);

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
