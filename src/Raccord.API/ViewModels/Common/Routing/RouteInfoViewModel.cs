using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Common.Routing
{
  public class RouteInfoViewModel
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