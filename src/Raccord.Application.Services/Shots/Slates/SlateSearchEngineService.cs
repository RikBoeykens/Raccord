using System;
using System.Linq;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Shots.Slates;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.Shots.Slates
{
    // Service to search for slates
    public class SlateSearchEngineService : ISlateSearchEngineService
    {
        private readonly EntityType _type = EntityType.Slate;
        private readonly ISlateRepository _slateRepository;

        // Initialises a new LocationSearchEngineService
        public SlateSearchEngineService(ISlateRepository slateRepository)
        {
            if(slateRepository == null)
                throw new ArgumentNullException(nameof(slateRepository));
            
            _slateRepository = slateRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var slateCount = _slateRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var slates = _slateRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = slateCount,
                Type = "Slates",
                Results = slates.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}