using Raccord.Domain.Model.Projects;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Projects
{
    // Interface defining a repository for Projects
    public interface IProjectRepository : IBaseRepository<Project>
    {
        int SearchCount(string searchText);
        IEnumerable<Project> Search(string searchText);
    }
}