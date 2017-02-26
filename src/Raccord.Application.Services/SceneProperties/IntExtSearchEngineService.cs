using System;
using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.SceneProperties
{
    // Service to search for int/ext
    public class IntExtSearchEngineService : IIntExtSearchEngineService
    {
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
            return EntityType.IntExt;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var intExtCount = _intExtRepository.SearchCount(request.SearchText, request.ProjectID);
            var intExts = _intExtRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = intExtCount,
                Type = "Int/Ext",
                Results = intExts.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}