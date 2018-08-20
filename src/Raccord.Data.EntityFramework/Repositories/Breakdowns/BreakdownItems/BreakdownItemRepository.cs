using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems
{
    // Repository for locations
    public class BreakdownItemRepository : BaseRepository<BreakdownItem, long>, IBreakdownItemRepository
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

        public int SearchCount(string searchText, long? projectID, long? typeID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, typeID, userID, isAdmin, excludeIds);

            return query.Count();            
        }

        public IEnumerable<BreakdownItem> Search(string searchText, long? projectID, long? typeID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, typeID, userID, isAdmin, excludeIds);
        }

        private IQueryable<BreakdownItem> GetIncludedFull()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownType)
                        .Include(bi => bi.Breakdown)
                            .ThenInclude(b => b.User)
                        .Include(bi=> bi.BreakdownItemScenes)
                            .ThenInclude(s=> s.Scene)
                                .ThenInclude(s=> s.SceneIntro)
                        .Include(bi=> bi.BreakdownItemScenes)
                            .ThenInclude(s=> s.Scene)
                                .ThenInclude(s=> s.ScriptLocation)
                        .Include(bi=> bi.BreakdownItemScenes)
                            .ThenInclude(s=> s.Scene)
                                .ThenInclude(s=> s.TimeOfDay)
                        .Include(bi=> bi.ImageBreakdownItems)
                            .ThenInclude(ibi=> ibi.Image);
        }

        private IQueryable<BreakdownItem> GetIncludedSummary()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownType)
                        .Include(bi=> bi.BreakdownItemScenes)
                        .Include(bi=> bi.ImageBreakdownItems)
                        .ThenInclude(ibi=> ibi.Image);
        }

        private IQueryable<BreakdownItem> GetIncluded()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownType);
        }

        private IQueryable<BreakdownItem> GetIncludedSearch()
        {
            IQueryable<BreakdownItem> query = _context.Set<BreakdownItem>();

            return query.Include(bi=> bi.BreakdownType)
                        .Include(bt=> bt.Breakdown)
                        .ThenInclude(bt=> bt.Project)
                        .ThenInclude(p=> p.ProjectUsers);
        }

        private IQueryable<BreakdownItem> GetSearchQuery(string searchText, long? projectID, long? typeID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetIncludedSearch();

            query = query.Where(bi=> bi.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(bi=> bi.Breakdown.ProjectID==projectID.Value);

            if(typeID.HasValue)
                query = query.Where(bi=> bi.BreakdownTypeID==typeID.Value);

            if(!isAdmin)
                query = query.Where(bi=> bi.Breakdown.Project.ProjectUsers.Any(c=> c.UserID == userID));

            if(excludeIds.Any())
            {
                query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
            }

            return query;
        }
    }
}
