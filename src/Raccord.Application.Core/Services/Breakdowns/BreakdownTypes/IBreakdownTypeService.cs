namespace Raccord.Application.Core.Services.Breakdowns.BreakdownTypes
{
    // Interface for breakdown type functionality
    public interface IBreakdownTypeService : IService<BreakdownTypeDto, BreakdownTypeSummaryDto, FullBreakdownTypeDto>, IAllForParentService<BreakdownTypeSummaryDto>
    {
    }
}