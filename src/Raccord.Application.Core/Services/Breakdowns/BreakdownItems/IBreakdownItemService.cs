using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Interface for breakdown item functionality
    public interface IBreakdownItemService : IService<BreakdownItemDto, BreakdownItemSummaryDto, FullBreakdownItemDto>, IAllForParentService<BreakdownItemSummaryDto>
    {
        // Merge two breakdown items
        void Merge(long toID, long mergeID);

        // Search for breakdown items by type
        IEnumerable<BreakdownItemDto> SearchByType(SearchBreakdownItemRequestDto requestDto);
    }
}