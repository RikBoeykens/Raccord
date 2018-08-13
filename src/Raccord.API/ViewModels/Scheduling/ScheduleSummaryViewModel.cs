using System;
using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Scheduling
{
  public class ScheduleSummaryViewModel
  {
    private CrewUnitViewModel _crewUnit;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
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