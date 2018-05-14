using System;
using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.SceneProperties
{
    // Service to search for day/night
    public class DayNightSearchEngineService : IDayNightSearchEngineService
    {
        private readonly EntityType _type = EntityType.DayNight;
        private readonly IDayNightRepository _dayNightRepository;

        // Initialises a new DayNightSearchEngineService
        public DayNightSearchEngineService(IDayNightRepository dayNightRepository)
        {
            if(dayNightRepository == null)
                throw new ArgumentNullException(nameof(dayNightRepository));
            
            _dayNightRepository = dayNightRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeIDs(_type);
            var dayNightCount = _dayNightRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var dayNights = _dayNightRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = dayNightCount,
                Type = "Day/Night",
                Results = dayNights.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}