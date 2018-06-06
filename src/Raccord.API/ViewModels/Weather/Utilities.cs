using Raccord.API.ViewModels.Common.Location;
using Raccord.Application.Core.ExternalServices.Weather;

namespace Raccord.API.ViewModels.Weather
{
  public static class Utilities
  {
    public static WeatherInfoViewModel Translate(this WeatherInfoDto dto)
    {
      if(dto == null)
      {
        return null;
      }
      return new WeatherInfoViewModel
      {
        Date = dto.Date,
        Summary = dto.Summary,
        Icon = dto.Icon,
        TemperatureLow = dto.TemperatureLow,
        TemperatureLowTime = dto.TemperatureLowTime,
        TemperatureHigh = dto.TemperatureHigh,
        TemperatureHighTime = dto.TemperatureHighTime,
        SunriseTime = dto.SunriseTime,
        SunsetTime = dto.SunsetTime,
        LatLng = dto.LatLng.Translate()
      };
    }
  }
}