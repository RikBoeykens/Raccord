using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Services.Common.Locations
{
    public static class LocationUtilities
    {
        public static AddressDto TranslateAddress(string address1, string address2, string address3, string address4)
        {
            return new AddressDto
            {
                Address1 = address1,
                Address2 = address2,
                Address3 = address3,
                Address4 = address4,
            };
        }

        public static LatLngDto TranslateLatLng(double? latitude, double? longitude)
        {
            return new LatLngDto
            {
                Latitude = latitude,
                Longitude = longitude,
            };
        }
    }
}