using Raccord.API.ViewModels.Profile;

namespace Raccord.API.ViewModels.Breakdowns
{
  public class BreakdownSummaryViewModel: BaseBreakdownViewModel
  {
    private UserProfileSummaryViewModel _createdBy;

    public UserProfileSummaryViewModel CreatedBy
    {
      get
      {
        return _createdBy ?? (_createdBy = new UserProfileSummaryViewModel());
      }
      set
      {
        _createdBy = value;
      }
    }
  }
}