using System;
using Raccord.API.ViewModels.Common.Routing;

namespace Raccord.API.ViewModels.Calendar
{
  public class CalendarItemViewModel
  {
    private RouteInfoViewModel _routeInfo;
    public DateTime Date { get;set; }
    public string Label { get;set; }
    public RouteInfoViewModel RouteInfo
    {
      get
      {
        return _routeInfo ?? new RouteInfoViewModel();
      }
      set
      {
        _routeInfo = value;
      }
    }
  }
}