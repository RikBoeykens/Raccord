using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Interface defining a repository for Int/Ext
    public interface ITimeOfDayRepository : IBaseRepository<TimeOfDay, long>
    {
        IEnumerable<TimeOfDay> GetAllForProject(long projectID);
        TimeOfDay GetFull(long ID);
        TimeOfDay GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<TimeOfDay> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}