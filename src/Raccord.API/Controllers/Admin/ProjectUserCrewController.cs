using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Users.Project.Crew;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Application.Core.Services.Users.Project.Crew;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectUserCrewController : AbstractAdminController
    {
        private readonly IProjectUserCrewService _projectUserCrewService;

        public ProjectUserCrewController(IProjectUserCrewService projectUserCrewService)
        {
            if (projectUserCrewService == null)
                throw new ArgumentNullException(nameof(projectUserCrewService));

            _projectUserCrewService = projectUserCrewService;
        }

        // POST api/projectusercrew
        [HttpPost]
        public JsonResult Post([FromBody]CreateUserCrewMemberViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();
                _projectUserCrewService.Create(dto);

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
                    message = "Something went wrong while attempting to add a crew member.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/projectusercrew/5/1/addlink
        [HttpPost("{projectUserId}/{crewMemberId}/addlink")]
        public JsonResult AddLink(long projectUserId, long crewMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserCrewService.LinkExisting(projectUserId, crewMemberId);

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
                    message = "Something went wrong while attempting to add link between user and crew member",
                };
            }

            return new JsonResult(response);
        }

        // POST api/projectusercrew/5/1/removelink
        [HttpPost("{projectUserId}/{crewMemberId}/removelink")]
        public JsonResult RemoveLink(long projectUserId, long crewMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserCrewService.RemoveLink(projectUserId, crewMemberId);

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
                    message = "Something went wrong while attempting to remove link between user and crew member",
                };
            }

            return new JsonResult(response);
        }
    }
}
