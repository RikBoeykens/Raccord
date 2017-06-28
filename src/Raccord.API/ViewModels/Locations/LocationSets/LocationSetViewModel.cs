using System;
using Raccord.API.ViewModels.Common.Location;

namespace Raccord.API.ViewModels.Locations.LocationSets
{
    // Vm to represent a scene on a location set
    public class LocationSetViewModel
    {
        private LatLngViewModel _latLng;
        // ID of the set
        public long ID { get; set; }

        // Name of the set
        public string Name { get; set; }

        // Description of the set
        public string Description { get; set; }

        // ID of the linked schedule day
        public long LocationID { get; set; }

        // ID of the linked scene
        public long ScriptLocationID { get; set; }

        // Address of the lat lng
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