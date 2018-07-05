using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.Application.Core.Common.Routing
{
    public class RouteInfoDto
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