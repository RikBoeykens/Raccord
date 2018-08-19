using Raccord.API.ViewModels.Callsheets;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Locations.Locations;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Dashboards
{
  public class CrewUnitDashboardViewModel
  {
    private CrewUnitViewModel _crewUnit;
    private PagedDataViewModel<ScheduleSummaryViewModel> _schedules;
    private PagedDataViewModel<CallsheetSummaryViewModel> _callsheets;
    private PagedDataViewModel<ShootingDaySummaryViewModel> _shootingDays;

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
    public PagedDataViewModel<ScheduleSummaryViewModel> Schedules
    {
      get
      {
        return _schedules ?? new PagedDataViewModel<ScheduleSummaryViewModel>();
      }
      set
      {
        _schedules = value;
      }
    }
    public PagedDataViewModel<CallsheetSummaryViewModel> Callsheets
    {
      get
      {
        return _callsheets ?? new PagedDataViewModel<CallsheetSummaryViewModel>();
      }
      set
      {
        _callsheets = value;
      }
    }
    public PagedDataViewModel<ShootingDaySummaryViewModel> ShootingDays
    {
      get
      {
        return _shootingDays ?? new PagedDataViewModel<ShootingDaySummaryViewModel>();
      }
      set
      {
        _shootingDays = value;
      }
    }
  }
}