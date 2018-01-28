using Raccord.Domain.Model.Projects;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Projects
{
    // Interface defining a repository for Projects
    public interface IProjectRepository : IBaseRepository<Project>
    {
        IEnumerable<Project> GetAllForUser(string userID);
        int SearchCount(string searchText, string userID, bool isAdmin, long[] excludeIds);
        Project GetFull(long ID);
        Project GetSummary(long ID);
        IEnumerable<Project> Search(string searchText, string userID, bool isAdmin, long[] excludeIds);
    }
}