using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CrewMembersController : AbstractApiAuthController
    {
        private readonly ICrewMemberService _crewMemberService;

        public CrewMembersController(
            ICrewMemberService crewMemberService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (crewMemberService == null)
                throw new ArgumentNullException(nameof(crewMemberService));

            _crewMemberService = crewMemberService;
        }

        // GET: api/crewmembers/1/department
        [HttpGet("{id}/department")]
        public IEnumerable<CrewMemberSummaryViewModel> GetAll(long id)
        {
            var dtos = _crewMemberService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/crewmembers/5
        [HttpGet("{id}")]
        public FullCrewMemberViewModel Get(long id)
        {
            var dto = _crewMemberService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/crewmembers/5/summary
        [HttpGet("{id}/summary")]
        public CrewMemberSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _crewMemberService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/crewmembers
        [HttpPost]
        public JsonResult Post([FromBody]CrewMemberViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _crewMemberService.Add(dto);
                }
                else
                {
                    id = _crewMemberService.Update(dto);
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
                    message = "Something went wrong while attempting to update crew member",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/crewmembers/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _crewMemberService.Delete(id);

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
                    message = "Something went wrong while attempting to delete crew member.",
                };
            }

            return new JsonResult(response);
        }
    }
}
