using System;
using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.SceneProperties
{
    // Service to search for day/night
    public class DayNightSearchEngineService : IDayNightSearchEngineService
    {
        private readonly IDayNightRepository _dayNightRepository;

        // Initialises a new DayNightSearchEngineService
        public DayNightSearchEngineService(IDayNightRepository dayNightRepository)
        {
            if(dayNightRepository == null)
                throw new ArgumentNullException(nameof(dayNightRepository));
            
            _dayNightRepository = dayNightRepository;
        }

        public new SearchType GetType()
        {
            return SearchType.DayNight;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var dayNightCount = _dayNightRepository.SearchCount(request.SearchText, request.ProjectID);
            var dayNights = _dayNightRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = dayNightCount,
                Type = "Day/Night",
                Results = dayNights.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}