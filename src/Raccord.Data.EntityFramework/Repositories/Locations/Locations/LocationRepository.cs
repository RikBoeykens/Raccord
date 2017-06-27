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

        private IQueryable<Location> GetIncludedFull()
        {
            IQueryable<Location> query = _context.Set<Location>();

            return query.Include(l=> l.LocationSets)
                        .ThenInclude(ls=> ls.ScriptLocation)
                        .ThenInclude(sl=> sl.ImageLocations)
                        .ThenInclude(il=> il.Image);
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
    }
}
