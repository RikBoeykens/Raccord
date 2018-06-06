using System;

namespace Raccord.Application.ExternalServices.Weather
{
  public static class Utilities
  {
    public static DateTime GetUtcDate(DateTime date, double offset)
    {
      return date.AddHours(offset).Date;
    }

    public static DateTime GetLocalDate(DateTime date)
    {
      return date;
    }

    public static bool IsInfoForDate(this DayInfo dayInfo, double offset, DateTime date)
    {
      return GetUtcDate(dayInfo.Time, offset) == date;
    }
  }
}