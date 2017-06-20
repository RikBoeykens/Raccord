using System;
using System.Linq;
using Raccord.Application.Core.Services.Locations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Locations
{
    // Service to search for locations
    public class LocationSearchEngineService : ILocationSearchEngineService
    {
        private readonly IScriptLocationRepository _scriptLocationRepository;

        // Initialises a new LocationSearchEngineService
        public LocationSearchEngineService(IScriptLocationRepository scriptLocationRepository)
        {
            if(scriptLocationRepository == null)
                throw new ArgumentNullException(nameof(scriptLocationRepository));
            
            _scriptLocationRepository = scriptLocationRepository;
        }

        public new EntityType GetType()
        {
            return EntityType.Location;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var locationCount = _scriptLocationRepository.SearchCount(request.SearchText, request.ProjectID);
            var locations = _scriptLocationRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = locationCount,
                Type = "Locations",
                Results = locations.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}