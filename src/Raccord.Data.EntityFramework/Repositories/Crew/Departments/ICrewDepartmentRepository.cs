using System.Collections.Generic;
using Raccord.Domain.Model.Crew.Departments;

namespace Raccord.Data.EntityFramework.Repositories.Crew.Departments
{
    // Interface defining a repository for Crew Department
    public interface ICrewDepartmentRepository : IBaseRepository<CrewDepartment, long>
    {
        IEnumerable<CrewDepartment> GetAllForUnit(long crewUnitID);
        CrewDepartment GetFull(long ID);
        CrewDepartment GetSummary(long ID);
    }
}