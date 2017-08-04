using Raccord.Domain.Model.Locations.Locations;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Locations.Locations
{
    // Interface defining a repository for Int/Ext
    public interface ILocationRepository : IBaseRepository<Location>
    {
        IEnumerable<Location> GetAllForProject(long projectID);
        Location GetFull(long ID);
        Location GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin);
        IEnumerable<Location> Search(string searchText, long? projectID, string userID, bool isAdmin);
    }
}