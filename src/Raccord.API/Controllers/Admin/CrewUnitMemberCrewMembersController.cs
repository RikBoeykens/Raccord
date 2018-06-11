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
    public class CrewUnitMemberCrewMembersController : AbstractAdminController
    {
        private readonly ICrewUnitMemberCrewMemberService _crewUnitMemberCrewMemberService;

        public CrewUnitMemberCrewMembersController(ICrewUnitMemberCrewMemberService crewUnitMemberCrewMemberService)
        {
            if (crewUnitMemberCrewMemberService == null)
                throw new ArgumentNullException(nameof(crewUnitMemberCrewMemberService));

            _crewUnitMemberCrewMemberService = crewUnitMemberCrewMemberService;
        }

        // POST api/crewunitmembercrewmembers
        [HttpPost]
        public JsonResult Post([FromBody]CreateCrewUnitMemberCrewMemberViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();
                _crewUnitMemberCrewMemberService.Create(dto);

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
        [HttpPost("{crewUnitMemberId}/{crewMemberId}/addlink")]
        public JsonResult AddLink(long crewUnitMemberId, long crewMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitMemberCrewMemberService.LinkExisting(crewUnitMemberId, crewMemberId);

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
        [HttpPost("{crewUnitMemberId}/{crewMemberId}/removelink")]
        public JsonResult RemoveLink(long crewUnitMemberId, long crewMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitMemberCrewMemberService.RemoveLink(crewUnitMemberId, crewMemberId);

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
