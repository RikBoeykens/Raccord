using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Users.Project;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectUsersController : AbstractAdminController
    {
        private readonly IProjectUserService _projectUserService;

        public ProjectUsersController(IProjectUserService projectUserService)
        {
            if (projectUserService == null)
                throw new ArgumentNullException(nameof(projectUserService));

            _projectUserService = projectUserService;
        }

        // GET: api/projectusers/1/projects
        [HttpGet("{userID}/projects")]
        public IEnumerable<ProjectUserProjectViewModel> GetProjects(string userID)
        {
            var dtos = _projectUserService.GetProjects(userID);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/projectusers/1/users
        [HttpGet("{projectID}/users")]
        public IEnumerable<ProjectUserUserViewModel> GetUsers(long projectID)
        {
            var dtos = _projectUserService.GetUsers(projectID);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET api/projectusers/5
        [HttpGet("{id}")]
        public FullProjectUserViewModel Get(long id)
        {
            var dto = _projectUserService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/projectusers
        [HttpPost]
        public JsonResult Post([FromBody]ProjectUserViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _projectUserService.Add(dto);
                }
                else
                {
                    id = _projectUserService.Update(dto);
                }

                response = new JsonResponse
                {
                    ok = true,
                    data = id,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to update project users",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/projectusers/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserService.Delete(id);

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
                    message = "Something went wrong while attempting to delete project users.",
                };
            }

            return new JsonResult(response);
        }
    }
}
