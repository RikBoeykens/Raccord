using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Crew.CrewUnits.Members;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Crew.CrewUnits.Members;

namespace Raccord.API.Controllers.Admin
{
    public class CrewUnitInvitationMemberCrewMembersController : AbstractAdminController
    {
        private readonly ICrewUnitInvitationMemberCrewMemberService _crewUnitInvitationMemberCrewMemberService;

        public CrewUnitInvitationMemberCrewMembersController(ICrewUnitInvitationMemberCrewMemberService crewUnitInvitationMemberCrewMemberService)
        {
            if (crewUnitInvitationMemberCrewMemberService == null)
                throw new ArgumentNullException(nameof(crewUnitInvitationMemberCrewMemberService));

            _crewUnitInvitationMemberCrewMemberService = crewUnitInvitationMemberCrewMemberService;
        }

        // POST api/crewunitinvitationmembercrewmembers
        [HttpPost]
        public JsonResult Post([FromBody]CreateCrewUnitMemberCrewMemberViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();
                _crewUnitInvitationMemberCrewMemberService.Create(dto);

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

        // POST api/crewunitmembercrewmembers/5/1/addlink
        [HttpPost("{crewUnitInvitationMemberId}/{crewMemberId}/addlink")]
        public JsonResult AddLink(long crewUnitInvitationMemberId, long crewMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitInvitationMemberCrewMemberService.LinkExisting(crewUnitInvitationMemberId, crewMemberId);

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

        // POST api/crewunitmembercrewmembers/5/1/removelink
        [HttpPost("{crewUnitInvitationMemberId}/{crewMemberId}/removelink")]
        public JsonResult RemoveLink(long crewUnitInvitationMemberId, long crewMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitInvitationMemberCrewMemberService.RemoveLink(crewUnitInvitationMemberId, crewMemberId);

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
