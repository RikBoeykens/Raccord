using Raccord.Domain.Model.Projects;
using System.Collections.Generic;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users.Projects
{
    // Interface defining a repository for ProjectUsers
    public interface IProjectUserRepository : IBaseRepository<ProjectUser>
    {
        IEnumerable<ProjectUser> GetAllForProject(long projectID);
        IEnumerable<ProjectUser> GetAllForUser(string userID);
        ProjectUser GetFull(long ID);
    }
}