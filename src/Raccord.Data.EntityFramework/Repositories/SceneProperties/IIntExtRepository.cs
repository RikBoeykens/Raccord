using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Interface defining a repository for Int/Ext
    public interface IIntExtRepository : IBaseRepository<IntExt, long>
    {
        IEnumerable<IntExt> GetAllForProject(long projectID);
        IntExt GetFull(long ID);
        IntExt GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<IntExt> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}