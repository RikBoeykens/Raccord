using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Dashboards
{
  public class ScriptDashboardViewModel
  {
    private PagedDataViewModel<SceneSummaryViewModel> _scenes;
    private PagedDataViewModel<ScriptLocationSummaryViewModel> _scriptLocations;
    private PagedDataViewModel<CharacterSummaryViewModel> _characters;

    public PagedDataViewModel<SceneSummaryViewModel> Scenes
    {
      get
      {
        return _scenes ?? new PagedDataViewModel<SceneSummaryViewModel>();
      }
      set
      {
        _scenes = value;
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
    public PagedDataViewModel<CharacterSummaryViewModel> Characters
    {
      get
      {
        return _characters ?? new PagedDataViewModel<CharacterSummaryViewModel>();
      }
      set
      {
        _characters = value;
      }
    }
  }
}