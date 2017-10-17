using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Crew.Departments
{
    // Interface for crew department functionality
    public interface ICrewDepartmentService
    {
        IEnumerable<CrewDepartmentDto> GetAllForProject(long projectID);
    }
}