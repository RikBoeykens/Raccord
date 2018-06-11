using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Crew.CrewUnits.Members;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Application.Core.Services.Users.Project.Cast;

namespace Raccord.API.Controllers.Admin
{
    public class CrewUnitInvitationMembersController : AbstractAdminController
    {
        private readonly ICrewUnitInvitationMemberService _crewUnitInvitationMemberService;

        public CrewUnitInvitationMembersController(ICrewUnitInvitationMemberService crewUnitInvitationMemberService)
        {
            _crewUnitInvitationMemberService = crewUnitInvitationMemberService;
        }

        // GET: api/crewunitmembers/1/crewunits
        [HttpGet("{id}/crewunits")]
        public IEnumerable<ProjectUserCrewUnitViewModel> GetCrewUnits(long id)
        {
            var dtos = _crewUnitInvitationMemberService.GetCrewUnits(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/crewunitmembers/5/1/addlink
        [HttpPost("{projectUserInvitationId}/{crewUnitId}/addlink")]
        public JsonResult AddLink(long projectUserInvitationId, long crewUnitId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitInvitationMemberService.AddLink(projectUserInvitationId, crewUnitId);

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
                    message = "Something went wrong while attempting to add link between user and unit",
                };
            }

            return new JsonResult(response);
        }

        // POST api/crewunitmembers/5/1/removelink
        [HttpPost("{crewUnitInvitationMemberId}/removelink")]
        public JsonResult RemoveLink(long crewUnitInvitationMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitInvitationMemberService.RemoveLink(crewUnitInvitationMemberId);

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
                    message = "Something went wrong while attempting to remove link between user and unit",
                };
            }

            return new JsonResult(response);
        }
    }
}
