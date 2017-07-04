using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Dto to represent a full location
    public class FullLocationDto: LocationDto
    {
        private IEnumerable<LocationSetScriptLocationDto> _sets;
        private IEnumerable<ScheduleDaySceneCollectionDto> _scheduleDays;

        // Sets linked to the location
        public IEnumerable<LocationSetScriptLocationDto> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<LocationSetScriptLocationDto>());
            }
            set
            {
                _sets = value;
            }
        }

        // Schedule days linked to the location
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