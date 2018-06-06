using System;
using Raccord.Application.Core.Common.Location;

namespace Raccord.Application.Core.ExternalServices.Weather
{
  public class WeatherInfoDto
  {
    private LatLngDto _latLng;
    public DateTime Date { get; set; }
    public string Summary { get; set; }
    public string Icon { get; set; }
    public double TemperatureLow { get; set; }
    public DateTime TemperatureLowTime { get; set; }
    public double TemperatureHigh { get; set; }
    public DateTime TemperatureHighTime { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
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