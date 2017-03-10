namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Interface for breakdown item functionality
    public interface IBreakdownItemService : IService<BreakdownItemDto, BreakdownItemSummaryDto, FullBreakdownItemDto>, IAllForParentService<BreakdownItemSummaryDto>
    {
        void Merge(long toID, long mergeID);
    }
}