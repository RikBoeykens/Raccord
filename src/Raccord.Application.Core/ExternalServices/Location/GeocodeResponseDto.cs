using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.ExternalServices.Location
{
  public class GeocodeResponseDto
  {
    private LatLngDto _latLng;
    
    public string FormattedAddress { get; set; }
    public LatLngDto LatLng
    {
      get { return _latLng ?? new LatLngDto(); }
      set { _latLng = value; }
    }
  }
}