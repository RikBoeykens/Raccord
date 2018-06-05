using System.Collections.Generic;
using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.ExternalServices.Location
{
  public interface IGeocodingService
  {
      IEnumerable<GeocodeResponseDto> GetLatLng(AddressDto request);
      IEnumerable<GeocodeResponseDto> GetLatLng(string searchText);
  }
}