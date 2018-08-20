using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Repository for Day/Night
    public class TimeOfDayRepository : BaseRepository<TimeOfDay, long>, ITimeOfDayRepository
    {
        public TimeOfDayRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<TimeOfDay> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(d=> d.ProjectID == projectID);
        }

        public TimeOfDay GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public TimeOfDay GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

            return query.Count();
        }

        public IEnumerable<TimeOfDay> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

        }

        private IQueryable<TimeOfDay> GetIncludedFull()
        {
            IQueryable<TimeOfDay> query = _context.Set<TimeOfDay>();

            return query.Include(d=> d.Scenes)
                        .ThenInclude(s=> s.SceneIntro)
                        .Include(d=> d.Scenes)
                        .ThenInclude(s=> s.ScriptLocation);
        }

        private IQueryable<TimeOfDay> GetIncludedSummary()
        {
            IQueryable<TimeOfDay> query = _context.Set<TimeOfDay>();

            return query.Include(d=> d.Scenes);
        }

        private IQueryable<TimeOfDay> GetIncluded()
        {
            IQueryable<TimeOfDay> query = _context.Set<TimeOfDay>();

            return query;
        }

        private IQueryable<TimeOfDay> GetIncludedSearch()
        {
            IQueryable<TimeOfDay> query = _context.Set<TimeOfDay>();

            return query.Include(d=> d.Project)
                        .ThenInclude(p=> p.ProjectUsers);
        }


        private IQueryable<TimeOfDay> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            IQueryable<TimeOfDay> query = GetIncludedSearch();

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
