namespace Raccord.Application.Core.Services.Shots.Takes
{
    // Interface for take functionality
    public interface ITakeService : IService<TakeDto, TakeSummaryDto, FullTakeDto>, IAllForParentService<TakeSummaryDto>
    {
    }
}