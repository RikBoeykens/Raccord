using Raccord.Application.Core.Common.Location;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.ScriptLocations;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a summary of a location set with script location info
    public class LocationSetScriptLocationDto
    {
        private LatLngDto _latLng;
        private ScriptLocationSummaryDto _scriptLocation;

        // ID of the set
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

        // Linked script location
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