using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users.Projects
{
    // Repository for preojct users
    public class ProjectUserRepository : BaseRepository<ProjectUser, long>, IProjectUserRepository
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

        public ProjectUser Get(long projectID, string userID)
        {
            var query = GetIncluded();

            return query.FirstOrDefault(pu => pu.ProjectID == projectID && pu.UserID == userID);
        }

        public ProjectUser GetForPermissions(long projectID, string userID)
        {
            var query = GetIncludedPermissions();

            return query.FirstOrDefault(cu=> cu.ProjectID == projectID && cu.UserID == userID);
        }

        private IQueryable<ProjectUser> GetIncludedFull()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(cs=> cs.User)
                        .Include(cu=> cu.Project)
                            .ThenInclude(p=> p.Images)
                        .Include(pu=> pu.Role)
                            .ThenInclude(r=> r.PermissionRoles)
                                .ThenInclude(pr => pr.ProjectPermission)
                        .Include(pu => pu.CastMember)
                            .ThenInclude(cm => cm.Characters)
                                .ThenInclude(c => c.ImageCharacters)
                                    .ThenInclude(ic => ic.Image)
                        .Include(pu => pu.CrewUnitMembers)
                            .ThenInclude(pu => pu.CrewUnit)
                        .Include(pu => pu.CrewUnitMembers)
                            .ThenInclude(pu => pu.CrewMembers)
                                .ThenInclude(cm => cm.Department);
        }

        private IQueryable<ProjectUser> GetIncluded()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query;
        }

        private IQueryable<ProjectUser> GetIncludedUser()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(cs=> cs.User)
                        .Include(pu => pu.Role);
        }

        private IQueryable<ProjectUser> GetIncludedProject()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(cs=> cs.Project)
                        .ThenInclude(p=> p.Images)
                        .Include(pu => pu.Role);
        }

        private IQueryable<ProjectUser> GetIncludedPermissions()
        {
            IQueryable<ProjectUser> query = _context.Set<ProjectUser>();

            return query.Include(pu=> pu.Role)
                        .ThenInclude(r=> r.PermissionRoles)
                        .ThenInclude(pr=> pr.ProjectPermission);
        }
    }
}
