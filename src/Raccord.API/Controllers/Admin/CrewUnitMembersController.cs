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
    public class CrewUnitMembersController : AbstractAdminController
    {
        private readonly ICrewUnitMemberService _crewUnitMemberService;

        public CrewUnitMembersController(ICrewUnitMemberService crewUnitMemberService)
        {
            if (crewUnitMemberService == null)
                throw new ArgumentNullException(nameof(crewUnitMemberService));

            _crewUnitMemberService = crewUnitMemberService;
        }

        // GET: api/crewunitmembers/1/characters
        [HttpGet("{id}/crewunits")]
        public IEnumerable<LinkedCrewUnitViewModel> GetCrewUnits(long id)
        {
            var dtos = _crewUnitMemberService.GetCrewUnits(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/crewunitmembers/1/scenes
        [HttpGet("{id}/projectusers")]
        public IEnumerable<LinkedProjectUserUserViewModel> GetProjectUsers(long id)
        {
            var dtos = _crewUnitMemberService.GetUsers(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/crewunitmembers/5/1/addlink
        [HttpPost("{projectUserId}/{crewUnitId}/addlink")]
        public JsonResult AddLink(long projectUserId, long crewUnitId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitMemberService.AddLink(projectUserId, crewUnitId);

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
        [HttpPost("{crewUnitMemberId}/removelink")]
        public JsonResult RemoveLink(long crewUnitMemberId)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitMemberService.RemoveLink(crewUnitMemberId);

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
