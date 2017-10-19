using System.Linq;
using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Domain.Model.Crew.Departments;

namespace Raccord.Application.Services.Crew.Departments
{
    // Utilities and helper methods for Crew departments
    public static class Utilities
    {
        public static FullCrewDepartmentDto TranslateFull(this CrewDepartment crewDepartment)
        {
            return new FullCrewDepartmentDto
            {
                ID = crewDepartment.ID,
                Name = crewDepartment.Name,
                Description = crewDepartment.Description,
                ProjectID = crewDepartment.ProjectID,
                CrewMembers = crewDepartment.Crew.Select(c=> c.TranslateSummary())
            };
        }
        public static CrewDepartmentDto Translate(this CrewDepartment crewDepartment)
        {
            return new CrewDepartmentDto
            {
                ID = crewDepartment.ID,
                Name = crewDepartment.Name,
                Description = crewDepartment.Description,
                ProjectID = crewDepartment.ProjectID,
            };
        }
    }
}