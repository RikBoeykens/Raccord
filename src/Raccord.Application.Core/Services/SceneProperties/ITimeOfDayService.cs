namespace Raccord.Application.Core.Services.SceneProperties
{
    // Interface for day/night functionality
    public interface ITimeOfDayService : IService<TimeOfDayDto, TimeOfDaySummaryDto, FullTimeOfDayDto>, IAllForParentService<TimeOfDaySummaryDto>
    {
        void Merge(long toID, long mergeID);
    }
}