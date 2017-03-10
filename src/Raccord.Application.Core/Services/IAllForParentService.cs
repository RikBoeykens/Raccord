using System.Collections.Generic;

namespace Raccord.Application.Core.Services
{
    // Interface for general service functionality
    public interface IAllForParentService<TSummary>
    {
        // Returns all as summary
        IEnumerable<TSummary> GetAllForParent(long parentID);
    }
}