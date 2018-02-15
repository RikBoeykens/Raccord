using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Application.Core.Services.Users.Project.Cast;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectUserCastController : AbstractAdminController
    {
        private readonly IProjectUserCastService _projectUserCastService;

        public ProjectUserCastController(IProjectUserCastService projectUserCastService)
        {
            if (projectUserCastService == null)
                throw new ArgumentNullException(nameof(projectUserCastService));

            _projectUserCastService = projectUserCastService;
        }

        // POST api/projectusercast/5/1/addlink
        [HttpPost("{projectUserId}/{characterId}/addlink")]
        public JsonResult AddLink(long projectUserId, long characterId)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserCastService.Link(projectUserId, characterId);

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
                    message = "Something went wrong while attempting to add link between user and character",
                };
            }

            return new JsonResult(response);
        }

        // POST api/projectusercast/5/1/removelink
        [HttpPost("{projectUserId}/{characterId}/removelink")]
        public JsonResult RemoveLink(long projectUserId, long characterId)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserCastService.RemoveLink(projectUserId, characterId);

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
                    message = "Something went wrong while attempting to remove link between user and character",
                };
            }

            return new JsonResult(response);
        }
    }
}
