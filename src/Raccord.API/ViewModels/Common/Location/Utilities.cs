using Raccord.Application.Core.Common.Location;

namespace Raccord.API.ViewModels.Common.Location
{
    public static class Utilities
    {
        public static AddressViewModel Translate(this AddressDto dto)
        {
            return new AddressViewModel
            {
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Address3 = dto.Address3,
                Address4 = dto.Address4,
            };
        }

        public static AddressDto Translate(this AddressViewModel vm)
        {
            return new AddressDto
            {
                Address1 = vm.Address1,
                Address2 = vm.Address2,
                Address3 = vm.Address3,
                Address4 = vm.Address4,
            };
        }
        public static LatLngViewModel Translate(this LatLngDto dto)
        {
            return new LatLngViewModel
            {
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
            };
        }

        public static LatLngDto Translate(this LatLngViewModel vm)
        {
            return new LatLngDto
            {
                Latitude = vm.Latitude,
                Longitude = vm.Longitude,
            };
        }
    }
}