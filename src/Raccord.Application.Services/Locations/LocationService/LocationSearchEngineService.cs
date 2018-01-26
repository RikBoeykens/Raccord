using System;
using System.Linq;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Locations.Locations;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.Locations.Locations
{
    // Service to search for locations
    public class LocationSearchEngineService : ILocationSearchEngineService
    {
        private readonly EntityType _type = EntityType.Location;
        private readonly ILocationRepository _locationRepository;

        // Initialises a new LocationSearchEngineService
        public LocationSearchEngineService(ILocationRepository locationRepository)
        {
            if(locationRepository == null)
                throw new ArgumentNullException(nameof(locationRepository));
            
            _locationRepository = locationRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeIDs(_type);
            var locationCount = _locationRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var locations = _locationRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = locationCount,
                Type = "Locations",
                Results = locations.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}