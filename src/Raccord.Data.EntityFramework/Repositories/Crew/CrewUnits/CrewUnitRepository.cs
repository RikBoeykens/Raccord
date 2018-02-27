using Raccord.Domain.Model.Crew.CrewUnits;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits
{
    // Repository for crew units
    public class CrewUnitRepository : BaseRepository<CrewUnit>, ICrewUnitRepository
    {
        public CrewUnitRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CrewUnit> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.ProjectID == projectID);
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
                                .ThenInclude(pu=> pu.User);
        }

        private IQueryable<CrewUnit> GetIncludedSummary()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query;
        }

        private IQueryable<CrewUnit> GetIncluded()
        {
            IQueryable<CrewUnit> query = _context.Set<CrewUnit>();

            return query;
        }
    }
}
