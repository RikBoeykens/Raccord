using System;
using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Dto to represent a location
    public class LocationDto
    {
        private AddressDto _address;
        private LatLngDto _latLng;

        // ID of the schedule day
        public long ID { get; set; }

        public string Name { get; set; }

        // ID of the project
        public long ProjectID { get; set; }

        // Address of the location
        public AddressDto Address
        {
            get 
            { 
                return _address ?? (_address = new AddressDto()); 
            }
            set
            { 
                _address = value;
            }
        }

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