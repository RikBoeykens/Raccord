using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Dashboards
{
  public class CastDashboardViewModel
  {
    private PagedDataViewModel<CastMemberSummaryViewModel> _castMembers;
    private PagedDataViewModel<CharacterSummaryViewModel> _characters;

    public PagedDataViewModel<CastMemberSummaryViewModel> CastMembers
    {
      get
      {
        return _castMembers ?? new PagedDataViewModel<CastMemberSummaryViewModel>();
      }
      set
      {
        _castMembers = value;
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