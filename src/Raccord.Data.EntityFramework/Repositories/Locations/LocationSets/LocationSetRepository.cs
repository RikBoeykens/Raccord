using Raccord.Domain.Model.Locations.LocationSets;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Locations.LocationSets
{
    // Repository for ScheduleScene
    public class LocationSetRepository : BaseRepository<LocationSet>, ILocationSetRepository
    {
        public LocationSetRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<LocationSet> GetAllForLocation(long locationID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.LocationID == locationID);
        }

        public IEnumerable<LocationSet> GetAllForScriptLocation(long scriptLocationID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.ScriptLocationID == scriptLocationID);
        }

        public LocationSet GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public LocationSet GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        private IQueryable<LocationSet> GetIncludedFull()
        {
            IQueryable<LocationSet> query = _context.Set<LocationSet>();

            return query.Include(ss=> ss.Location)
                        .Include(ss=> ss.ScriptLocation)
                        .ThenInclude(s=> s.ImageLocations)
                        .ThenInclude(ss=> ss.Image);
        }

        private IQueryable<LocationSet> GetIncludedSummary()
        {
            IQueryable<LocationSet> query = _context.Set<LocationSet>();

            return query.Include(ss=> ss.Location)
                        .Include(ss=> ss.ScriptLocation)
                        .ThenInclude(s=> s.ImageLocations)
                        .ThenInclude(ss=> ss.Image);
        }

        private IQueryable<LocationSet> GetIncluded()
        {
            IQueryable<LocationSet> query = _context.Set<LocationSet>();

            return query;
        }
    }
}
