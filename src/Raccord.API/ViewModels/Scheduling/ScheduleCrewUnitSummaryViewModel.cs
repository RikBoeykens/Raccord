using System;
using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Scheduling
{
  public class ScheduleCrewUnitSummaryViewModel : ScheduleSummaryViewModel
  {
    private CrewUnitViewModel _crewUnit;
    public CrewUnitViewModel CrewUnit
    {
      get
      {
        return _crewUnit ?? (_crewUnit = new CrewUnitViewModel());
      }
      set
      {
        _crewUnit = value;
      }
    }
  }
}