using Raccord.API.ViewModels.Profile;

namespace Raccord.API.ViewModels.Breakdowns
{
  public class BreakdownSummaryViewModel: BaseBreakdownViewModel
  {
    private UserProfileSummaryViewModel _createdBy;

    /// <summary>
    /// Indicates if the user has selected this breakdown
    /// </summary>
    /// <returns></returns>
    public bool Selected { get; set; }

    public bool IsPublished { get; set; }
    public bool IsDefault { get; set; }

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