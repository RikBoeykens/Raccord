using Raccord.Application.Core.Common.Routing;
using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.SearchEngine
{
    //  Dto to represent a single result from the search engine
    public class SearchResultDto
    {
        private RouteInfoDto _routeInfo;
        // ID of the result
        public object ID { get; set;}

        // Display name
        public string DisplayName { get; set; }

        // Optional extra info
        public string Info { get; set; }

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