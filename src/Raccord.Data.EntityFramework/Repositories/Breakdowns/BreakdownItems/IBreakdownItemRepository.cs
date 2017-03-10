using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems
{
    // Interface defining a repository for breakdown items
    public interface IBreakdownItemRepository : IBaseRepository<BreakdownItem>
    {
        IEnumerable<BreakdownItem> GetAllForType(long typeID);
        BreakdownItem GetFull(long ID);
        BreakdownItem GetSummary(long ID);
        int SearchCount(string searchText, long? projectID);
        IEnumerable<BreakdownItem> Search(string searchText, long? typeID);
    }
}