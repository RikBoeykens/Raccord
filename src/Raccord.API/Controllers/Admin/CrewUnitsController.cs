using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.API.Controllers.Admin
{
    public class CrewUnitsController : AbstractAdminController
    {
        private readonly ICrewUnitService _crewUnitService;

        public CrewUnitsController(ICrewUnitService crewUnitMemberService)
        {
            if (crewUnitMemberService == null)
                throw new ArgumentNullException(nameof(crewUnitMemberService));

            _crewUnitService = crewUnitMemberService;
        }

        // GET api/crewunits/5
        [HttpGet("{id}")]
        public FullAdminCrewUnitViewModel Get(long id)
        {
            var dto = _crewUnitService.GetForAdmin(id);

            return dto.Translate();
        }

        // GET: api/crewunits/1/project
        [HttpGet("{projectId}/project")]
        public IEnumerable<CrewUnitSummaryViewModel> GetAll([FromRoute]long projectId)
        {
            var dtos = _crewUnitService.GetAllForParent(projectId);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
    }
}
