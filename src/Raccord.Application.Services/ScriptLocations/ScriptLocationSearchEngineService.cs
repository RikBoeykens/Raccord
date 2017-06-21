using System;
using System.Linq;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.ScriptLocations
{
    // Service to search for locations
    public class ScriptLocationSearchEngineService : IScriptLocationSearchEngineService
    {
        private readonly IScriptLocationRepository _scriptLocationRepository;

        // Initialises a new LocationSearchEngineService
        public ScriptLocationSearchEngineService(IScriptLocationRepository scriptLocationRepository)
        {
            if(scriptLocationRepository == null)
                throw new ArgumentNullException(nameof(scriptLocationRepository));
            
            _scriptLocationRepository = scriptLocationRepository;
        }

        public new EntityType GetType()
        {
            return EntityType.ScriptLocation;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var locationCount = _scriptLocationRepository.SearchCount(request.SearchText, request.ProjectID);
            var locations = _scriptLocationRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = locationCount,
                Type = "Script Locations",
                Results = locations.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}