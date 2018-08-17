using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.Application.Core.Services.Scheduling;

namespace Raccord.API.ViewModels.Scheduling
{
  public static class Utilities
  {
    public static ScheduleCrewUnitSummaryViewModel Translate(this ScheduleCrewUnitSummaryDto dto)
    {
      if (dto == null)
      {
        return null;
      }
      return new ScheduleCrewUnitSummaryViewModel
      {
        CrewUnit = dto.CrewUnit.Translate(),
        StartDate = dto.StartDate,
        EndDate = dto.EndDate
      };
    }
    public static ScheduleSummaryViewModel Translate(this ScheduleSummaryDto dto)
    {
      if (dto == null)
      {
        return null;
      }
      return new ScheduleSummaryViewModel
      {
        StartDate = dto.StartDate,
        EndDate = dto.EndDate
      };
    }
  }
}