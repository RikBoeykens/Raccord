using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.Application.Core.Services.Crew;
using Raccord.Application.Core.Services.Crew.Departments;

namespace Raccord.API.ViewModels.Crew.Departments
{
    public static class Utilities
    {
        public static CrewDepartmentViewModel Translate(this CrewDepartmentDto dto)
        {
            return new CrewDepartmentViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }
    }
}