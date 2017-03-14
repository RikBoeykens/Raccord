using System;
using System.Linq;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Breakdowns.BreakdownItems
{
    // Service to search for breakdown items
    public class BreakdownItemSearchEngineService : IBreakdownItemSearchEngineService
    {
        private readonly IBreakdownItemRepository _breakdownItemRepository;

        // Initialises a new BreakdownItemSearchEngineService
        public BreakdownItemSearchEngineService(IBreakdownItemRepository breakdownItemRepository)
        {
            if(breakdownItemRepository == null)
                throw new ArgumentNullException(nameof(breakdownItemRepository));
            
            _breakdownItemRepository = breakdownItemRepository;
        }

        public new EntityType GetType()
        {
            return EntityType.BreakdownItem;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var itemCount = _breakdownItemRepository.SearchCount(request.SearchText, request.ProjectID);
            var items = _breakdownItemRepository.Search(request.SearchText, projectID: request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = itemCount,
                Type = "Breakdown",
                Results = items.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}