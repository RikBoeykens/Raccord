using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a set for a location and script location
    public class LocationSetSummaryDto
    {
        private LatLngDto _latLng;
        private LocationSummaryDto _location;
        private ScriptLocationSummaryDto _scriptLocation;

        // ID of the schedule scene
        public long ID { get; set; }

        // Name of the set
        public string Name { get; set; }

        // Description of the set
        public string Description { get; set; }

        // Lat lng of the set
        public LatLngDto LatLng
        {
            get 
            { 
                return _latLng ?? (_latLng = new LatLngDto()); 
            }
            set
            { 
                _latLng = value;
            }
        }

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