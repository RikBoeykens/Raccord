using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Repository for Int/Ext
    public class IntExtRepository : BaseRepository<IntExt>, IIntExtRepository
    {
        public IntExtRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<IntExt> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public IntExt GetFull(long ID)
        {
            var query = GetIncludedIntExt();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public IntExt GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();
        }

        public IEnumerable<IntExt> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);
        }

        private IQueryable<IntExt> GetIncludedIntExt()
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            return query.Include(i=> i.Scenes)
                        .ThenInclude(s=> s.Location)
                        .Include(i=> i.Scenes)
                        .ThenInclude(s=> s.DayNight);
        }

        private IQueryable<IntExt> GetIncludedSummary()
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            return query;
        }

        private IQueryable<IntExt> GetSearchQuery(string searchText, long? projectID)
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            return query;
        }
    }
}
