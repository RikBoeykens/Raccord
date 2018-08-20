using Raccord.API.ViewModels.Callsheets;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Locations.Locations;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Dashboards
{
  public class ScheduleDashboardViewModel
  {
    private PagedDataViewModel<ScheduleCrewUnitSummaryViewModel> _schedules;
    private PagedDataViewModel<CallsheetCrewUnitViewModel> _callsheets;
    private PagedDataViewModel<ShootingDayCrewUnitViewModel> _shootingDays;

    public PagedDataViewModel<ScheduleCrewUnitSummaryViewModel> Schedules
    {
      get
      {
        return _schedules ?? new PagedDataViewModel<ScheduleCrewUnitSummaryViewModel>();
      }
      set
      {
        _schedules = value;
      }
    }
    public PagedDataViewModel<CallsheetCrewUnitViewModel> Callsheets
    {
      get
      {
        return _callsheets ?? new PagedDataViewModel<CallsheetCrewUnitViewModel>();
      }
      set
      {
        _callsheets = value;
      }
    }
    public PagedDataViewModel<ShootingDayCrewUnitViewModel> ShootingDays
    {
      get
      {
        return _shootingDays ?? new PagedDataViewModel<ShootingDayCrewUnitViewModel>();
      }
      set
      {
        _shootingDays = value;
      }
    }
  }
}