using System.Linq;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.Application.Core.Services.Crew;
using Raccord.Application.Core.Services.Crew.Departments;

namespace Raccord.API.ViewModels.Crew.Departments
{
    public static class Utilities
    {
        public static FullCrewDepartmentViewModel Translate(this FullCrewDepartmentDto dto)
        {
            return new FullCrewDepartmentViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                CrewUnitID = dto.CrewUnitID,
                CrewMembers = dto.CrewMembers.Select(cm=> cm.Translate())
            };
        }
        public static CrewDepartmentViewModel Translate(this CrewDepartmentDto dto)
        {
            return new CrewDepartmentViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                CrewUnitID = dto.CrewUnitID,
            };
        }
        public static CrewDepartmentDto Translate(this CrewDepartmentViewModel vm)
        {
            return new CrewDepartmentDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                CrewUnitID = vm.CrewUnitID,
            };
        }
    }
}