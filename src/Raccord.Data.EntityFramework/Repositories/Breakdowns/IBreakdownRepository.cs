using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns
{
    // Interface defining a repository for Breakdown
    public interface IBreakdownRepository : IBaseRepository<Breakdown, long>
    {
        IEnumerable<Breakdown> GetAllForParent(long projectID);
        IEnumerable<Breakdown> GetAllForParent(long projectID, string userID);
        Breakdown GetFull(long ID);
        Breakdown GetSummary(long ID);
        Breakdown GetForProjectUser(long projectID, string userID);
        bool ProjectUserHasSelected(long projectID, string userID);
        Breakdown GetProjectUserSelected(long projectID, string userID);
        bool ProjectHasDefault(long projectID);
        Breakdown GetDefaultProject(long projectID);
    }
}