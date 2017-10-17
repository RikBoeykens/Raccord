using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Domain.Model.Crew.Departments;

namespace Raccord.Application.Services.Crew.Departments
{
    // Utilities and helper methods for Crew departments
    public static class Utilities
    {
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