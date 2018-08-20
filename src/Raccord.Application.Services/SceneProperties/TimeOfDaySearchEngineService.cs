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
    public class TimeOfDaySearchEngineService : ITimeOfDaySearchEngineService
    {
        private readonly EntityType _type = EntityType.TimeOfDay;
        private readonly ITimeOfDayRepository _timeOfDayRepository;

        // Initialises a new DayNightSearchEngineService
        public TimeOfDaySearchEngineService(ITimeOfDayRepository timeOfDayRepository)
        {
            if(timeOfDayRepository == null)
                throw new ArgumentNullException(nameof(timeOfDayRepository));
            
            _timeOfDayRepository = timeOfDayRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var timeOfDayCount = _timeOfDayRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var timesOfDay = _timeOfDayRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = timeOfDayCount,
                Type = "Time of Day",
                Results = timesOfDay.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}