using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Crew;

namespace Raccord.Data.EntityFramework.Repositories.Crew
{
    // Repository for crew users
    public class CrewRepository : BaseRepository<CrewUser>, ICrewRepository
    {
        public CrewRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CrewUser> GetAllForProject(long projectID)
        {
            var query = GetIncludedUser();

            return query.Where(c=> c.ProjectID == projectID);
        }

        public IEnumerable<CrewUser> GetAllForUser(string userID)
        {
            var query = GetIncludedProject();

            return query.Where(c=> c.UserID == userID);
        }

        private IQueryable<CrewUser> GetIncludedUser()
        {
            IQueryable<CrewUser> query = _context.Set<CrewUser>();

            return query.Include(cs=> cs.User);
        }

        private IQueryable<CrewUser> GetIncludedProject()
        {
            IQueryable<CrewUser> query = _context.Set<CrewUser>();

            return query.Include(cs=> cs.Project)
                        .ThenInclude(p=> p.Images);
        }
    }
}
