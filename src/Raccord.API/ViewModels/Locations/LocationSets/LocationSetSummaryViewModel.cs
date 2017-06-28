using Raccord.API.ViewModels.Common.Location;
using Raccord.API.ViewModels.Locations.Locations;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Locations.LocationSets
{
    // Viewmodel to represent a set
    public class LocationSetSummaryViewModel
    {
        private LocationSummaryViewModel _location;
        private ScriptLocationSummaryViewModel _scriptLocation;
        private LatLngViewModel _latLng;
        
        // ID of the set
        public long ID { get; set; }

        // Name of the set
        public string Name { get; set; }

        // Description of the set
        public string Description { get; set; }

        // Location
        public LocationSummaryViewModel Location
        {
            get 
            { 
                return _location ?? (_location = new LocationSummaryViewModel()); 
            }
            set
            { 
                _location = value;
            }
        }

        // ScriptLocation
        public ScriptLocationSummaryViewModel ScriptLocation
        {
            get 
            { 
                return _scriptLocation ?? (_scriptLocation = new ScriptLocationSummaryViewModel()); 
            }
            set
            { 
                _scriptLocation = value;
            }
        }

        // Lat lng of the set
        public LatLngViewModel LatLng
        {
            get 
            { 
                return _latLng ?? (_latLng = new LatLngViewModel()); 
            }
            set
            { 
                _latLng = value;
            }
        }
    }
}