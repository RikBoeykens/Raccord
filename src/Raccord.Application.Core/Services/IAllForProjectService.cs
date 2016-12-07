using System.Collections.Generic;

namespace Raccord.Application.Core.Services
{
    // Interface for general service functionality
    public interface IAllForProjectService<TSummary>
    {
        // Returns all as summary
        IEnumerable<TSummary> GetAllForProject(long projectID);
    }
}