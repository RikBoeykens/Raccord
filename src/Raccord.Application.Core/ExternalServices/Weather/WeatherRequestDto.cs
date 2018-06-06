using System;
using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.ExternalServices.Weather
{
  public class WeatherRequestDto
  {
    private LatLngDto _latLng;
    public DateTime Date { get; set; }
    public LatLngDto LatLng
    {
      get
      {
        return _latLng ?? new LatLngDto();
      }
      set
      {
        _latLng = value;
      }
    }
  }
}