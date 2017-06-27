using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.Locations.Locations;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a set for a location and script location
    public class LocationSetSummaryDto
    {
        private LocationSummaryDto _location;
        private ScriptLocationSummaryDto _scriptLocation;

        // ID of the schedule scene
        public long ID { get; set; }

        // Linked scene
        public LocationSummaryDto Location
        {
            get
            {
                return _location ?? (_location = new LocationSummaryDto()); 
            }
            set
            {
                _location = value;
            }
        }

        // Linked schedule day
        public ScriptLocationSummaryDto ScriptLocation
        {
            get
            {
                return _scriptLocation ?? (_scriptLocation = new ScriptLocationSummaryDto()); 
            }
            set
            {
                _scriptLocation = value;
            }
        }
    }
}