using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users.Projects
{
    // Repository for preojct users
    public class ProjectUserRepository : BaseRepository<ProjectUser>, IProjectUserRepository
    {
        public ProjectUserRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ProjectUser> GetAllForProject(long projectID)
        {
            var query = GetIncludedUser();

            return query.Where(c=> c.ProjectID == projectID);
        }

        public IEnumerable<ProjectUser> GetAllForUser(string userID)
        {
            var query = GetIncludedProject();

            return query.Where(c=> c.UserID == userID);
        }

        public ProjectUser GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(cu=> cu.ID == ID);
        }

        private IQueryable<ProjectUser> GetIncludedFull()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(cs=> cs.User)
                        .Include(cu=> cu.Project)
                        .ThenInclude(p=> p.Images)
                        .Include(pu=> pu.CrewMembers)
                        .ThenInclude(cm=> cm.Department);
        }

        private IQueryable<ProjectUser> GetIncludedUser()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(cs=> cs.User);
        }

        private IQueryable<ProjectUser> GetIncludedProject()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(cs=> cs.Project)
                        .ThenInclude(p=> p.Images);
        }
    }
}
