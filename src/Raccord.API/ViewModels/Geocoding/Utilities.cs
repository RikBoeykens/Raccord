using Raccord.API.ViewModels.Common.Location;
using Raccord.Application.Core.ExternalServices.Location;

namespace Raccord.API.ViewModels.Geocoding
{
  public static class Utilities
  {
    public static GeocodeResponseViewModel Translate(this GeocodeResponseDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new GeocodeResponseViewModel
      {
        FormattedAddress = dto.FormattedAddress,
        LatLng = dto.LatLng.Translate(),
      };
    }
  }
}