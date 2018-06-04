using Raccord.API.ViewModels.Common.Location;

namespace Raccord.API.ViewModels.Geocoding
{
  public class GeocodeResponseViewModel
  {
    private LatLngViewModel _latLng;
    
    public string FormattedAddress { get; set; }
    public LatLngViewModel LatLng
    {
      get { return _latLng ?? new LatLngViewModel(); }
      set { _latLng = value; }
    }
  }
}