using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.ShootingDays
{
    public interface IShootingDayService
    {
        IEnumerable<ShootingDayCrewUnitDto> GetAvailableForCallsheet(long projectID);
        IEnumerable<ShootingDayCrewUnitDto> GetAvailableForCompletion(long projectID);
        IEnumerable<ShootingDayCrewUnitDto> GetCompleted(long projectID);
        PagedDataDto<ShootingDaySummaryDto> GetCompletedForCrewUnitPaged(long crewUnitID, PaginationRequestDto requestDto);
        PagedDataDto<ShootingDayCrewUnitDto> GetCompletedForProjectPaged(long projectID, PaginationRequestDto requestDto);
        IEnumerable<ShootingDayDto> GetAll(long projectID);
        FullShootingDayDto GetFull(long ID);
        ShootingDaySummaryDto GetSummary(long ID);
        long PrepareForCompletion(long ID);
        long Update(ShootingDayDto dto);
    }
}