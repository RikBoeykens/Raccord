using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Repository for Day/Night
    public class DayNightRepository : BaseRepository<DayNight>, IDayNightRepository
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
            var query = GetIncludedDayNight();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public DayNight GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();
        }

        public IEnumerable<DayNight> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);

        }

        private IQueryable<DayNight> GetIncludedDayNight()
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            return query.Include(d=> d.Scenes)
                        .ThenInclude(s=> s.IntExt)
                        .Include(d=> d.Scenes)
                        .ThenInclude(s=> s.Location);
        }

        private IQueryable<DayNight> GetIncludedSummary()
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            return query;
        }


        private IQueryable<DayNight> GetSearchQuery(string searchText, long? projectID)
        {
            IQueryable<DayNight> query = _context.Set<DayNight>();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            return query;
        }
    }
}
