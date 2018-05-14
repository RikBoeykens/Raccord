using System;
using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.SceneProperties
{
    // Service to search for int/ext
    public class IntExtSearchEngineService : IIntExtSearchEngineService
    {
        private readonly EntityType _type = EntityType.IntExt;
        private readonly IIntExtRepository _intExtRepository;

        // Initialises a new IntExtSearchEngineService
        public IntExtSearchEngineService(IIntExtRepository intExtRepository)
        {
            if(intExtRepository == null)
                throw new ArgumentNullException(nameof(intExtRepository));
            
            _intExtRepository = intExtRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeIDs(_type);
            var intExtCount = _intExtRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var intExts = _intExtRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = intExtCount,
                Type = "Int/Ext",
                Results = intExts.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}