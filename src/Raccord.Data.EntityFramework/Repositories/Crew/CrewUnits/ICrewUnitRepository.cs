using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewUnits;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits
{
    // Interface defining a repository for crew units
    public interface ICrewUnitRepository : IBaseRepository<CrewUnit, long>
    {
        IEnumerable<CrewUnit> GetAllForProject(long projectID);
        IEnumerable<CrewUnit> GetAllForUser(long projectID, string userID);
        CrewUnit GetFull(long ID);
        CrewUnit GetFullAdmin(long ID);
        CrewUnit GetSummary(long ID);
    }
}