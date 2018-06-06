using System;
using System.Collections.Generic;

namespace Raccord.Application.ExternalServices.Weather
{
  public class DarkskyResponse
  {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Timezone { get; set; }
    public double Offset { get; set; }
    public DailyInfo Daily { get; set; }
  }

  public class DailyInfo
  {
    public IEnumerable<DayInfo> Data { get; set; }
  }

  public class DayInfo
  {
    public DateTime Time { get; set; }
    public string Summary { get; set; }
    public string Icon { get; set; }
    public double TemperatureLow { get; set; }
    public DateTime TemperatureLowTime { get; set; }
    public double TemperatureHigh { get; set; }
    public DateTime TemperatureHighTime { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }

  }
}