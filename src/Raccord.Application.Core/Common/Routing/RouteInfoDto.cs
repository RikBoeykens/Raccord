using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.Application.Core.Common.Routing
{
    public class RouteInfoDto
    {
      private IEnumerable<long> _routeIDs;
      public EntityType Type { get; set; }
      public IEnumerable<long> RouteIDs
      {
        get
        {
          return _routeIDs ?? new List<long>();
        }
        set
        {
          _routeIDs = value;
        }
      }
    }
}