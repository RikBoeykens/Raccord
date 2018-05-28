using Raccord.Domain.Model.Projects;
using System.Collections.Generic;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users.Projects
{
    // Interface defining a repository for ProjectUsers
    public interface IProjectUserRepository : IBaseRepository<ProjectUser, long>
    {
        IEnumerable<ProjectUser> GetAllForProject(long projectID);
        IEnumerable<ProjectUser> GetAllForUser(string userID);
        ProjectUser GetFull(long ID);
        ProjectUser Get(long projectID, string userID);
        ProjectUser GetForPermissions(long projectID, string userID);
    }
}