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

    public PagedDataDto<ScheduleSummaryDto> GetSchedulesPaged(long projectId, PaginationRequestDto requestDto)
    {
      var scheduleSummaries = new List<ScheduleSummaryDto>();

      var crewUnits = _crewUnitRepository.GetAllForProject(projectId);

      foreach(var crewUnit in crewUnits)
      {
        var scheduleDays = _scheduleDayRepository.GetAllForCrewUnit(crewUnit.ID).OrderBy(sd => sd.ShootingDay.Date);
        var firstDay = scheduleDays.FirstOrDefault();
        var lastDay = scheduleDays.LastOrDefault();
        scheduleSummaries.Add(new ScheduleSummaryDto
        {
          CrewUnit = crewUnit.Translate(),
          StartDate = firstDay.ShootingDay.Date,
          EndDate = firstDay.ShootingDay.Date
        });
      }

      return scheduleSummaries.GetPaged<ScheduleSummaryDto, ScheduleSummaryDto>(requestDto, x => x);
    }
  }
}