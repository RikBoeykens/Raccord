using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes
{
    // Interface defining a repository for Breakdown type
    public interface IBreakdownTypeRepository : IBaseRepository<BreakdownType>
    {
        IEnumerable<BreakdownType> GetAllForProject(long projectID);
        BreakdownType GetFull(long ID);
        BreakdownType GetSummary(long ID);
    }
}