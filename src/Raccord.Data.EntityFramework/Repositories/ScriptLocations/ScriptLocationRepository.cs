using Raccord.Domain.Model.ScriptLocations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.ScriptLocations
{
    // Repository for locations
    public class ScriptLocationRepository : BaseRepository<ScriptLocation>, IScriptLocationRepository
    {
        public ScriptLocationRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ScriptLocation> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(l=> l.ProjectID == projectID);
        }

        public ScriptLocation GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public ScriptLocation GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();            
        }

        public IEnumerable<ScriptLocation> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);
        }

        private IQueryable<ScriptLocation> GetIncludedFull()
        {
            IQueryable<ScriptLocation> query = _context.Set<ScriptLocation>();

            return query.Include(l=> l.Scenes)
                        .ThenInclude(s=> s.IntExt)
                        .Include(l=> l.Scenes)
                        .ThenInclude(s=> s.DayNight)
                        .Include(l=> l.ImageLocations)
                        .ThenInclude(il=> il.Image)
                        .Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.Location);
        }

        private IQueryable<ScriptLocation> GetIncludedSummary()
        {
            IQueryable<ScriptLocation> query = _context.Set<ScriptLocation>();

            return query.Include(l=> l.Scenes)
                        .Include(l=> l.ImageLocations)
                        .ThenInclude(il=> il.Image);
        }

        private IQueryable<ScriptLocation> GetIncluded()
        {
            IQueryable<ScriptLocation> query = _context.Set<ScriptLocation>();

            return query;
        }

        private IQueryable<ScriptLocation> GetIncludedSearch()
        {
            IQueryable<ScriptLocation> query = _context.Set<ScriptLocation>();

            return query.Include(l=> l.Project);
        }

        private IQueryable<ScriptLocation> GetSearchQuery(string searchText, long? projectID)
        {
            var query = GetIncludedSearch();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            return query;
        }
    }
}
