using System;
using System.Linq;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.ScriptLocations
{
    // Service to search for locations
    public class ScriptLocationSearchEngineService : IScriptLocationSearchEngineService
    {
        private readonly EntityType _type = EntityType.ScriptLocation;
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
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var locationCount = _scriptLocationRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var locations = _scriptLocationRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = locationCount,
                Type = "Script Locations",
                Results = locations.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}