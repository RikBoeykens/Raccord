using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.API.ViewModels.Users.Invitations;
using Raccord.Application.Core.Services.Users.Invitations.Project;
using Raccord.API.ViewModels.Users.Invitations.Project;

namespace Raccord.API.Controllers.Admin
{
    public class ProjectUserInvitationsController : AbstractAdminController
    {
        private readonly IProjectUserInvitationService _projectUserInvitationService;

        public ProjectUserInvitationsController(IProjectUserInvitationService projectUserInvitationService)
        {
            _projectUserInvitationService = projectUserInvitationService;
        }

        // GET: api/admin/users
        [HttpGet("{id}/projects")]
        public IEnumerable<ProjectUserInvitationProjectViewModel> Get(Guid id)
        {
            var dtos = _projectUserInvitationService.GetProjects(id);

            return dtos.Select(p => p.Translate());
        }
        // GET: api/admin/users
        [HttpGet("{id}/invitations")]
        public IEnumerable<ProjectUserInvitationUserInvitationViewModel> GetInvitations(long id)
        {
            var dtos = _projectUserInvitationService.GetInvitations(id);

            return dtos.Select(p => p.Translate());
        }
        // GET api/admin/users/5
        [HttpGet("{id}")]
        public AdminFullProjectUserInvitationViewModel Get(long id)
        {
            var dto = _projectUserInvitationService.Get(id);

            return dto.Translate();
        }
        // GET api/admin/users/5
        [HttpGet("{id}/summary")]
        public ProjectUserInvitationSummaryViewModel GetSummary(long id)
        {
            var dto = _projectUserInvitationService.GetSummary(id);

            return dto.Translate();
        }

        // POST api/admin/users/create
        [HttpPost("create")]
        public JsonResult Create([FromBody]ProjectUserInvitationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var userID  = _projectUserInvitationService.Add(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = userID,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to add project user invitation",
                };
            }

            return new JsonResult(response);
        }

        // POST api/admin/users/update
        [HttpPost("update")]
        public JsonResult Update([FromBody]ProjectUserInvitationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var userID = _projectUserInvitationService.Update(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = userID,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to update project user invitation",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/admin/users/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _projectUserInvitationService.Delete(id);

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
                    message = "Something went wrong while attempting to delete project user invitation.",
                };
            }

            return new JsonResult(response);
        }
    }
}
