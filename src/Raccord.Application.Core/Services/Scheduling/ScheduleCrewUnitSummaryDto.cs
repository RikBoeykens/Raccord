using System;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.Application.Core.Services.Scheduling
{
  public class ScheduleCrewUnitSummaryDto : ScheduleSummaryDto
  {
    private CrewUnitDto _crewUnit;
    public CrewUnitDto CrewUnit
    {
      get
      {
        return _crewUnit ?? (_crewUnit = new CrewUnitDto());
      }
      set
      {
        _crewUnit = value;
      }
    }
  }
}