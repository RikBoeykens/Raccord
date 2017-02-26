using System;
using System.Linq;
using Raccord.Application.Core.Services.Locations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Locations;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Locations
{
    // Service to search for locations
    public class LocationSearchEngineService : ILocationSearchEngineService
    {
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
            return EntityType.Location;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var locationCount = _locationRepository.SearchCount(request.SearchText, request.ProjectID);
            var locations = _locationRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = locationCount,
                Type = "Locations",
                Results = locations.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}