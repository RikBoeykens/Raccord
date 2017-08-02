using Raccord.Domain.Model.Projects;
using System.Collections.Generic;
using Raccord.Domain.Model.Crew;

namespace Raccord.Data.EntityFramework.Repositories.Crew
{
    // Interface defining a repository for Crew
    public interface ICrewRepository : IBaseRepository<CrewUser>
    {
        IEnumerable<CrewUser> GetAllForProject(long projectID);
        IEnumerable<CrewUser> GetAllForUser(string userID);
    }
}