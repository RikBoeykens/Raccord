using System;
using Raccord.API.ViewModels.Common.Location;

namespace Raccord.API.ViewModels.Locations.Locations
{
    // Viewmodel to represent a location
    public class LocationViewModel
    {
        private AddressViewModel _address;
        private LatLngViewModel _latLng;

        // ID of the schedule day
        public long ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // ID of the project
        public long ProjectID { get; set; }

        // Address of the location
        public AddressViewModel Address
        {
            get 
            { 
                return _address ?? (_address = new AddressViewModel()); 
            }
            set
            { 
                _address = value;
            }
        }

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