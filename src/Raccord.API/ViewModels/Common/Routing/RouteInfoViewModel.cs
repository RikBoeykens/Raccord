using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Common.Routing
{
  public class RouteInfoViewModel
  {
      private IEnumerable<object> _routeIDs;
      public EntityType Type { get; set; }
      public IEnumerable<object> RouteIDs
      {
        get
        {
          return _routeIDs ?? new List<object>();
        }
        set
        {
          _routeIDs = value;
        }
      }
  }
}