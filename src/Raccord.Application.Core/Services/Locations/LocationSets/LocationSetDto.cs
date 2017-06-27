using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a scene on a schedule day
    public class LocationSetDto
    {
        private LatLngDto _latLng;

        // ID of the set
        public long ID { get; set; }

        // Name of the set
        public string Name { get; set; }

        // Description of the set
        public string Description { get; set; }

        // ID of the linked location
        public long LocationID { get; set; }

        // ID of the linked scene
        public long ScriptLocationID { get; set; }

        // Address of the lat lng
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
    }
}