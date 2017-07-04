using Raccord.Application.Core.Common.Location;
using Raccord.Application.Core.Services.Locations.Locations;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a summary of a schedule scene with 
    public class LocationSetLocationDto
    {
        private LatLngDto _latLng;
        private LocationSummaryDto _location;

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

        // Linked location
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
    }
}