using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ShootingDays
{
    public interface IShootingDayService
    {
        IEnumerable<ShootingDayCrewUnitDto> GetAvailableForCallsheet(long projectID);
        IEnumerable<ShootingDayCrewUnitDto> GetAvailableForCompletion(long projectID);
        IEnumerable<ShootingDaySummaryDto> GetCompleted(long crewUnitID);
        IEnumerable<ShootingDayDto> GetAll(long projectID);
        FullShootingDayDto GetFull(long ID);
        ShootingDaySummaryDto GetSummary(long ID);
        long PrepareForCompletion(long ID);
        long Update(ShootingDayDto dto);
    }
}