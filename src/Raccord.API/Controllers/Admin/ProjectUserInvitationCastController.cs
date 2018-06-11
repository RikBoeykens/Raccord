using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Users.Invitations.Project.Cast;
using Raccord.Application.Core.Services.Users.Invitations.Project;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectUserInvitationCastController : AbstractAdminController
    {
        private readonly IProjectUserInvitationCastService _projectUserInvitationCastService;

        public ProjectUserInvitationCastController(IProjectUserInvitationCastService projectUserInvitationCastService)
        {
            if (projectUserInvitationCastService == null)
                throw new ArgumentNullException(nameof(projectUserInvitationCastService));

            _projectUserInvitationCastService = projectUserInvitationCastService;
        }

        // POST api/projectusercast/5/1/addlink
        [HttpPost("{projectUserInvitationId}/{castMemberId}/addlink")]
        public JsonResult AddLink(long projectUserInvitationId, long castMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserInvitationCastService.Link(projectUserInvitationId, castMemberId);

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
        [HttpPost("{projectUserInvitationId}/{castMemberId}/removelink")]
        public JsonResult RemoveLink(long projectUserInvitationId, long castMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserInvitationCastService.RemoveLink(projectUserInvitationId, castMemberId);

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
