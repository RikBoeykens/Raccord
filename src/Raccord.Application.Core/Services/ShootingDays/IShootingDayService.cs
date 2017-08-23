using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ShootingDays
{
    public interface IShootingDayService
    {
        IEnumerable<ShootingDayDto> GetAvailableDays(long projectID);
        IEnumerable<ShootingDayDto> GetAvailableForCompletion(long projectID);
        IEnumerable<ShootingDaySummaryDto> GetCompleted(long projectID);
        IEnumerable<ShootingDayDto> GetAll(long projectID);
        FullShootingDayDto GetFull(long ID);
        ShootingDaySummaryDto GetSummary(long ID);
        void PrepareForCompletion(long ID);
        void Update(ShootingDayDto dto);
    }
}