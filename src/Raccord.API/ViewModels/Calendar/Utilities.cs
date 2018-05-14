using Raccord.API.ViewModels.Common.Routing;
using Raccord.Application.Core.Services.Calendar;

namespace Raccord.API.ViewModels.Calendar
{
  public static class Utilities
  {
    public static CalendarItemViewModel Translate(this CalendarItemDto dto)
    {
      return new CalendarItemViewModel
      {
        Label = dto.Label,
        Date = dto.Date,
        RouteInfo = dto.RouteInfo.Translate(),
      };
    }
  }
}