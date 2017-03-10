using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems
{
    // Repository for locations
    public class BreakdownItemRepository : BaseRepository<BreakdownItem>, IBreakdownItemRepository
    {
        public BreakdownItemRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<BreakdownItem> GetAllForType(long typeID)
        {
            var query = GetIncludedSummary();

            return query.Where(l=> l.BreakdownTypeID == typeID);
        }

        public BreakdownItem GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public BreakdownItem GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public int SearchCount(string searchText, long? typeID)
        {
            var query = GetSearchQuery(searchText, typeID);

            return query.Count();            
        }

        public IEnumerable<BreakdownItem> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);
        }

        private IQueryable<BreakdownItem> GetIncludedFull()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownItemScenes)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(bi=> bi.BreakdownItemScenes)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.Location)
                        .Include(bi=> bi.BreakdownItemScenes)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(bi=> bi.ImageBreakdownItems)
                        .ThenInclude(ibi=> ibi.Image);
        }

        private IQueryable<BreakdownItem> GetIncludedSummary()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownItemScenes)
                        .Include(bi=> bi.ImageBreakdownItems)
                        .ThenInclude(ibi=> ibi.Image);
        }

        private IQueryable<BreakdownItem> GetIncluded()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query;
        }

        private IQueryable<BreakdownItem> GetIncludedSearch()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownType)
                        .ThenInclude(bt=> bt.Project);
        }

        private IQueryable<BreakdownItem> GetSearchQuery(string searchText, long? typeID)
        {
            var query = GetIncludedSearch();

            query = query.Where(bi=> bi.Name.ToLower().Contains(searchText.ToLower()));

            if(typeID.HasValue)
                query = query.Where(bi=> bi.BreakdownTypeID==typeID.Value);

            return query;
        }
    }
}
