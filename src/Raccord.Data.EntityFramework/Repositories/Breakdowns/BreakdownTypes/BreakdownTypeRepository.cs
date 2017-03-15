using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes
{
    // Repository for breakdown types
    public class BreakdownTypeRepository : BaseRepository<BreakdownType>, IBreakdownTypeRepository
    {
        public BreakdownTypeRepository(RaccordDBContext context) : base(context) 
        {
        }


        public IEnumerable<BreakdownType> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(l=> l.ProjectID == projectID);
        }

        public BreakdownType GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public BreakdownType GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        private IQueryable<BreakdownType> GetIncludedFull()
        {
            IQueryable<BreakdownType> query = _context.Set<BreakdownType>();

            return query.Include(bt=> bt.BreakdownItems)
                        .ThenInclude(bi=> bi.ImageBreakdownItems)
                        .ThenInclude(ibi=> ibi.Image)
                        .Include(bt=> bt.BreakdownItems)
                        .ThenInclude(bi=> bi.BreakdownItemScenes);
        }

        private IQueryable<BreakdownType> GetIncludedSummary()
        {
            IQueryable<BreakdownType> query = _context.Set<BreakdownType>();

            return query.Include(bt=> bt.BreakdownItems);
        }

        private IQueryable<BreakdownType> GetIncluded()
        {
            IQueryable<BreakdownType> query = _context.Set<BreakdownType>();

            return query;
        }
    }
}
