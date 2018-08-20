using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Scheduling
{
    // Interface for location functionality
    public interface IScheduleService
    {
      PagedDataDto<ScheduleCrewUnitSummaryDto> GetSchedulesForProjectPaged(long projectId, PaginationRequestDto requestDto);
      PagedDataDto<ScheduleSummaryDto> GetSchedulesForCrewUnitPaged(long crewUnitId, PaginationRequestDto requestDto);
    }
}