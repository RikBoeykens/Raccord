using Raccord.Domain.Model.Crew.CrewUnits;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits
{
    // Repository for crew units
    public class CrewUnitRepository : BaseRepository<CrewUnit, long>, ICrewUnitRepository
    {
        public CrewUnitRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CrewUnit> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.ProjectID == projectID);
        }

        public IEnumerable<CrewUnit> GetAllForUser(long projectID, string userID)
        {
            var query = GetIncludedUserSummary();

            return query.Where(cu=> cu.ProjectID == projectID && 
                                    cu.CrewUnitMembers.Any(cum => 
                                        cum.ProjectUser.ProjectID == projectID && 
                                        cum.ProjectUser.UserID == userID));
        }
        public CrewUnit GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public CrewUnit GetFullAdmin(long ID)
        {
            var query = GetIncludedFullAdmin();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public CrewUnit GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        private IQueryable<CrewUnit> GetIncludedFull()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query;
        }

        private IQueryable<CrewUnit> GetIncludedFullAdmin()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query.Include(cu => cu.CrewUnitMembers)
                            .ThenInclude(cum => cum.ProjectUser)
                                .ThenInclude(pu=> pu.User)
                        .Include(cu => cu.CrewUnitMembers)
                            .ThenInclude(cum => cum.ProjectUser)
                                .ThenInclude(pu=> pu.Role);
        }

        private IQueryable<CrewUnit> GetIncludedSummary()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query;
        }

        private IQueryable<CrewUnit> GetIncludedUserSummary()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query.Include(cu=> cu.CrewUnitMembers)
                            .ThenInclude(cum => cum.ProjectUser);
        }

        private IQueryable<CrewUnit> GetIncluded()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query;
        }
    }
}
