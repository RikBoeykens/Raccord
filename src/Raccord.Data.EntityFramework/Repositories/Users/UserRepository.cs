using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        protected RaccordDBContext _context;

        public UserRepository(RaccordDBContext context)
        {
            _context = context;
        }

        public ApplicationUser Get(string ID)
        {
            var query = GetIncluded();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public ApplicationUser GetSummary(string ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public ApplicationUser GetFull(string ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public ApplicationUser GetForPermissions(string ID)
        {
            var query = GetIncludedPermissions();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var query = GetIncludedSummary();

            return query;
        }

        public virtual void Edit(ApplicationUser user)
        {
            EntityEntry dbEntityEntry = _context.Entry<ApplicationUser>(user);
            dbEntityEntry.State = EntityState.Modified;
        }
        
        public virtual void Commit()
        {
            _context.SaveChanges();
        }

        private IQueryable<ApplicationUser> GetIncluded()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query;
        }

        private IQueryable<ApplicationUser> GetIncludedFull()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query.Include(u=> u.ProjectUsers)
                            .ThenInclude(pu=> pu.Role)
                        .Include(u => u.ProjectUsers)
                            .ThenInclude(pu => pu.CrewUnitMembers)
                                .ThenInclude(cum => cum.CrewMembers)
                                    .ThenInclude(cm => cm.Department)
                                        .ThenInclude(d => d.CrewUnit)
                        .Include(u => u.ProjectUsers)
                            .ThenInclude(pu => pu.CastMember)
                                .ThenInclude(cm => cm.Characters);
        }

        private IQueryable<ApplicationUser> GetIncludedPermissions()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query.Include(u=> u.ProjectUsers)
                        .ThenInclude(pu=> pu.Role)
                        .ThenInclude(pu=> pu.PermissionRoles)
                        .ThenInclude(pr=> pr.ProjectPermission);
        }

        private IQueryable<ApplicationUser> GetIncludedSummary()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query;
        }
    }
}