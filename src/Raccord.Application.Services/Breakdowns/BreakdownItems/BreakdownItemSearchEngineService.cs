using System;
using System.Linq;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.Breakdowns.BreakdownItems
{
    // Service to search for breakdown items
    public class BreakdownItemSearchEngineService : IBreakdownItemSearchEngineService
    {
        private readonly EntityType _type = EntityType.BreakdownItem;
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
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var itemCount = _breakdownItemRepository.SearchCount(request.SearchText, projectID: request.ProjectID, typeID: null, userID: request.UserID, isAdmin: request.IsAdminSearch, excludeIds: excludeIds);
            var items = _breakdownItemRepository.Search(request.SearchText, projectID: request.ProjectID, typeID: null, userID: request.UserID, isAdmin: request.IsAdminSearch, excludeIds: excludeIds);

            return new SearchTypeResultDto
            {
                Count = itemCount,
                Type = "Breakdown",
                Results = items.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}