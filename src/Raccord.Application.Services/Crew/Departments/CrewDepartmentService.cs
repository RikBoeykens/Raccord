using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Data.EntityFramework.Repositories.Crew.Departments;

namespace Raccord.Application.Services.Crew.Departments
{
    // Service used for crew functionality
    public class CrewDepartmentService : ICrewDepartmentService
    {
        private readonly ICrewDepartmentRepository _crewDepartmentRepository;

        // Initialises a new CallsheetSceneService
        public CrewDepartmentService(
            ICrewDepartmentRepository crewDepartmentRepository
        )
        {
            if (crewDepartmentRepository == null)
                throw new ArgumentNullException(nameof(crewDepartmentRepository));

            _crewDepartmentRepository = crewDepartmentRepository;
        }

        // Gets all callsheet scenes for a scene
        public IEnumerable<FullCrewDepartmentDto> GetAllForUnit(long unitID)
        {
            var departments = _crewDepartmentRepository.GetAllForUnit(unitID);
            return departments.Select(d=> d.TranslateFull());
        }
    }
}