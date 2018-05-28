using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Interface defining a repository for Int/Ext
    public interface IDayNightRepository : IBaseRepository<DayNight, long>
    {
        IEnumerable<DayNight> GetAllForProject(long projectID);
        DayNight GetFull(long ID);
        DayNight GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<DayNight> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}