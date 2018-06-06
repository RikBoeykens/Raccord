using System;
using Raccord.API.ViewModels.Common.Location;

namespace Raccord.API.ViewModels.Weather
{
  public class WeatherInfoViewModel
  {
    private LatLngViewModel _latLng;
    public DateTime Date { get; set; }
    public string Summary { get; set; }
    public string Icon { get; set; }
    public double TemperatureLow { get; set; }
    public DateTime TemperatureLowTime { get; set; }
    public double TemperatureHigh { get; set; }
    public DateTime TemperatureHighTime { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public LatLngViewModel LatLng
    {
      get
      {
        return _latLng ?? new LatLngViewModel();
      }
      set
      {
        _latLng = value;
      }
    }
  }
}