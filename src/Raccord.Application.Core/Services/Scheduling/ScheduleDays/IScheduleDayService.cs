using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Interface for location functionality
    public interface IScheduleDayService : IService<ScheduleDayDto, ScheduleDaySummaryDto, FullScheduleDayDto>, IAllForParentService<FullScheduleDayDto>
    {
        IEnumerable<FullScheduleDayCrewUnitDto> GetForProjectUser(long projectID, string userID);
        void PublishDays(long crewUnitID);
    }
}