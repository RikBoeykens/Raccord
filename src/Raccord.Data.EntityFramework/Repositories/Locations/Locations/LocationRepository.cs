using Raccord.Domain.Model.Locations.Locations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Locations.Locations
{
    // Repository for ScheduleDay
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Location> GetAllForProject(long projectID)
        {
            var query = GetIncludedFull();

            return query.Where(sd=> sd.ProjectID == projectID);
        }

        public Location GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public Location GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin);

            return query.Count();            
        }

        public IEnumerable<Location> Search(string searchText, long? projectID, string userID, bool isAdmin)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin);
        }

        private IQueryable<Location> GetIncludedFull()
        {
            IQueryable<Location> query = _context.Set<Location>();

            return query.Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScriptLocation)
                        .ThenInclude(sl=> sl.ImageLocations)
                        .ThenInclude(il=> il.Image)
                        .Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image)
                        .Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScheduleScenes)
                        .ThenInclude(ss=> ss.ScheduleDay)
                        .ThenInclude(sd=> sd.ShootingDay);
        }

        private IQueryable<Location> GetIncludedSummary()
        {
            IQueryable<Location> query = _context.Set<Location>();

            return query.Include(sd=> sd.LocationSets);
        }

        private IQueryable<Location> GetIncluded()
        {
            IQueryable<Location> query = _context.Set<Location>();

            return query;
        }

        private IQueryable<Location> GetIncludedSearch()
        {
            IQueryable<Location> query = _context.Set<Location>();

            return query.Include(l=> l.Project)
                        .ThenInclude(p=> p.Crew);
        }

        private IQueryable<Location> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetIncludedSearch();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(l=> l.Project.Crew.Any(c=> c.UserID == userID));

            return query;
        }
    }
}
