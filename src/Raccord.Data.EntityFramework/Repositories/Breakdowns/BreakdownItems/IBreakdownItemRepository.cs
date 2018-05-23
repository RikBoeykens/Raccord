using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems
{
    // Interface defining a repository for breakdown items
    public interface IBreakdownItemRepository : IBaseRepository<BreakdownItem, long>
    {
        IEnumerable<BreakdownItem> GetAllForType(long typeID);
        BreakdownItem GetFull(long ID);
        BreakdownItem GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, long? typeID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<BreakdownItem> Search(string searchText, long? projectID, long? typeID, string userID, bool isAdmin, long[] excludeIds);
    }
}