using Raccord.Domain.Model.ScriptLocations;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.ScriptLocations
{
    // Interface defining a repository for Locations
    public interface IScriptLocationRepository : IBaseRepository<ScriptLocation>
    {
        IEnumerable<ScriptLocation> GetAllForProject(long projectID);
        ScriptLocation GetFull(long ID);
        ScriptLocation GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<ScriptLocation> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}