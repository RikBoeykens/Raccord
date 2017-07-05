namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Interface for location functionality
    public interface IScheduleDayService : IService<ScheduleDayDto, ScheduleDaySummaryDto, FullScheduleDayDto>, IAllForParentService<FullScheduleDayDto>
    {
        void PublishDays(long projectID);
    }
}