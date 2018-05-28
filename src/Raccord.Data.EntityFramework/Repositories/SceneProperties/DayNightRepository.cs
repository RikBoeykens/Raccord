using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Repository for Day/Night
    public class DayNightRepository : BaseRepository<DayNight, long>, IDayNightRepository
    {
        public DayNightRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<DayNight> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(d=> d.ProjectID == projectID);
        }

        public DayNight GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public DayNight GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

            return query.Count();
        }

        public IEnumerable<DayNight> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

        }

        private IQueryable<DayNight> GetIncludedFull()
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            return query.Include(d=> d.Scenes)
                        .ThenInclude(s=> s.IntExt)
                        .Include(d=> d.Scenes)
                        .ThenInclude(s=> s.ScriptLocation);
        }

        private IQueryable<DayNight> GetIncludedSummary()
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            return query.Include(d=> d.Scenes);
        }

        private IQueryable<DayNight> GetIncluded()
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            return query;
        }

        private IQueryable<DayNight> GetIncludedSearch()
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            return query.Include(d=> d.Project)
                        .ThenInclude(p=> p.ProjectUsers);
        }


        private IQueryable<DayNight> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            IQueryable<DayNight> query = GetIncludedSearch();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(l=> l.Project.ProjectUsers.Any(c=> c.UserID == userID));

            if(excludeIds.Any())
            {
                query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
            }

            return query;
        }
    }
}
