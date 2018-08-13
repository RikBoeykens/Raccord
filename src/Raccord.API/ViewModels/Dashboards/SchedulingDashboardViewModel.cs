using Raccord.API.ViewModels.Callsheets;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Locations.Locations;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Dashboards
{
  public class ScheduleDashboardViewModel
  {
    private PagedDataViewModel<ScheduleSummaryViewModel> _schedules;
    private PagedDataViewModel<CallsheetCrewUnitViewModel> _callsheets;

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
  }
}