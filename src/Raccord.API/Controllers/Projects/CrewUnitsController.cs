using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.Filters;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class CrewUnitsController : AbstractProjectsController
    {
        private readonly ICrewUnitService _crewUnitService;

        public CrewUnitsController(
            ICrewUnitService crewUnitService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (crewUnitService == null)
                throw new ArgumentNullException(nameof(crewUnitService));

            _crewUnitService = crewUnitService;
        }

        // GET: api/crewunits/1/project
        [HttpGet("project")]
        public IEnumerable<CrewUnitSummaryViewModel> GetAll(long authProjectId)
        {
            var dtos = _crewUnitService.GetAllForParent(authProjectId);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/crewunits/1/user
        [HttpGet("user")]
        public IEnumerable<CrewUnitSummaryViewModel> GetAllForUser(long authProjectId)
        {
            var dtos = _crewUnitService.GetAllForUser(authProjectId, GetUserId());

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/crewunits/5
        [HttpGet("{id}")]
        public FullCrewUnitViewModel Get(long id)
        {
            var dto = _crewUnitService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/crewunits/5
        [HttpGet("{id}/summary")]
        public CrewUnitSummaryViewModel GetSummary(long id)
        {
            var dto = _crewUnitService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/crewunits
        [HttpPost]
        public JsonResult Post([FromBody]CrewUnitViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _crewUnitService.Add(dto);
                }
                else
                {
                    id = _crewUnitService.Update(dto);
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
                    message = "Something went wrong while attempting to update crew unit",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/crewunits/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _crewUnitService.Delete(id);

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
                    message = "Something went wrong while attempting to delete crew unit.",
                };
            }

            return new JsonResult(response);
        }
    }
}
