namespace Raccord.Application.Core.Services.SceneProperties
{
    // Interface for day/night functionality
    public interface IDayNightService : IService<DayNightDto, DayNightSummaryDto, FullDayNightDto>, IAllForParentService<DayNightSummaryDto>
    {
        void Merge(long toID, long mergeID);
    }
}