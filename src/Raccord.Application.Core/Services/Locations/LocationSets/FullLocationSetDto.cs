using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.ScriptLocations;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a full schedule scene
    public class FullLocationSetDto : LocationSetSummaryDto
    {
        private IEnumerable<ScheduleDaySceneCollectionDto> _scheduleDays;

        // Schedule days linked to the location set
        public IEnumerable<ScheduleDaySceneCollectionDto> ScheduleDays
        {
            get
            {
                return _scheduleDays ?? (_scheduleDays = new List<ScheduleDaySceneCollectionDto>());
            }
            set
            {
                _scheduleDays = value;
            }
        }
    }
}