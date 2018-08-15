using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.Services.Scheduling;
using Raccord.Application.Services.Crew.CrewUnits;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;

namespace Raccord.Application.Services.Scheduling
{
  // Service used for schedule functionality
  public class ScheduleService : IScheduleService
  {
    private readonly ICrewUnitRepository _crewUnitRepository;
    private readonly IScheduleDayRepository _scheduleDayRepository;
    public ScheduleService(
      ICrewUnitRepository crewUnitRepository,
      IScheduleDayRepository scheduleDayRepository
    ) {
      _crewUnitRepository = crewUnitRepository;
      _scheduleDayRepository = scheduleDayRepository;
    }

    public PagedDataDto<ScheduleCrewUnitSummaryDto> GetSchedulesForProjectPaged(long projectId, PaginationRequestDto requestDto)
    {
      var scheduleSummaries = new List<ScheduleCrewUnitSummaryDto>();

      var crewUnits = _crewUnitRepository.GetAllForProject(projectId);

      foreach(var crewUnit in crewUnits)
      {
        var scheduleDays = _scheduleDayRepository.GetAllForCrewUnit(crewUnit.ID).OrderBy(sd => sd.ShootingDay.Date);
        var firstDay = scheduleDays.FirstOrDefault();
        var lastDay = scheduleDays.LastOrDefault();
        scheduleSummaries.Add(new ScheduleCrewUnitSummaryDto
        {
          CrewUnit = crewUnit.Translate(),
          StartDate = firstDay.ShootingDay.Date,
          EndDate = firstDay.ShootingDay.Date
        });
      }

      return scheduleSummaries.GetPaged<ScheduleCrewUnitSummaryDto, ScheduleCrewUnitSummaryDto>(requestDto, x => x);
    }
  }
}