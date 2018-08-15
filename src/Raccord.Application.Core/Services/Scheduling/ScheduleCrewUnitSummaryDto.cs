using System;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.Application.Core.Services.Scheduling
{
  public class ScheduleCrewUnitSummaryDto
  {
    private CrewUnitDto _crewUnit;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
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