using Raccord.Domain.Model.Locations.LocationSets;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Locations.LocationSets
{
    // Interface defining a repository for Int/Ext
    public interface ILocationSetRepository : IBaseRepository<LocationSet>
    {
        IEnumerable<LocationSet> GetAllForLocation(long locationID);
        IEnumerable<LocationSet> GetAllForScriptLocation(long scriptLocationID);
        LocationSet GetFull(long ID);
        LocationSet GetSummary(long ID);
    }
}