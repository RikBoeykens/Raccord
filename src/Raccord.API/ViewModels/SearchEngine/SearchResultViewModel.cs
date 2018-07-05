using Raccord.API.ViewModels.Common.Routing;
using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.SearchEngine
{
    // Viewmodel for a single search result
    public class SearchResultViewModel
    {
        private RouteInfoViewModel _routeInfo;
        // ID of the result
        public object ID { get; set; }

        // Display name
        public string DisplayName { get; set; }

        // Optional extra info
        public string Info { get; set; }

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