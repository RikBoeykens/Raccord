using Raccord.Domain.Model.Locations.LocationSets;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Locations.LocationSets
{
    // Interface defining a repository for Int/Ext
    public interface ILocationSetRepository : IBaseRepository<LocationSet, long>
    {
        IEnumerable<LocationSet> GetAllForLocation(long locationID);
        IEnumerable<LocationSet> GetAllForScriptLocation(long scriptLocationID);
        IEnumerable<LocationSet> GetAllForScene(long sceneID);
        LocationSet GetFull(long ID);
        LocationSet GetSummary(long ID);
    }
}