using System;
using Raccord.Application.Core.Common.Routing;

namespace Raccord.Application.Core.Services.Calendar
{
  public class CalendarItemDto
  {
    private RouteInfoDto _routeInfo;
    public DateTime Date { get;set; }
    public string Label { get;set; }
    public RouteInfoDto RouteInfo
    {
      get
      {
        return _routeInfo ?? new RouteInfoDto();
      }
      set
      {
        _routeInfo = value;
      }
    }
  }
}