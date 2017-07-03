using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Interface for location functionality
    public interface ILocationSetService
    {
        IEnumerable<LocationSetLocationDto> GetLocations(long scriptLocationID);

        IEnumerable<LocationSetScriptLocationDto> GetScriptLocations(long locationID);

        IEnumerable<LocationSetSummaryDto> GetSetsForScene(long sceneID);

        FullLocationSetDto Get(long ID);

        long Add(LocationSetDto dto);

        long Update(LocationSetDto dto);

        void Delete(long ID);
    }
}