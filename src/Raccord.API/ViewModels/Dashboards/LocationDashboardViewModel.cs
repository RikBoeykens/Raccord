using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Locations.Locations;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Dashboards
{
  public class LocationDashboardViewModel
  {
    private PagedDataViewModel<LocationSummaryViewModel> _locations;
    private PagedDataViewModel<ScriptLocationSummaryViewModel> _scriptLocations;

    public PagedDataViewModel<LocationSummaryViewModel> Locations
    {
      get
      {
        return _locations ?? new PagedDataViewModel<LocationSummaryViewModel>();
      }
      set
      {
        _locations = value;
      }
    }
    public PagedDataViewModel<ScriptLocationSummaryViewModel> ScriptLocations
    {
      get
      {
        return _scriptLocations ?? new PagedDataViewModel<ScriptLocationSummaryViewModel>();
      }
      set
      {
        _scriptLocations = value;
      }
    }
  }
}