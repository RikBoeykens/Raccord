using Raccord.Application.Core.Services.Profile;

namespace Raccord.Application.Core.Services.Breakdowns
{
  public class BreakdownSummaryDto: BaseBreakdownDto
  {
    private UserProfileSummaryDto _createdBy;

    /// <summary>
    /// Indicates if the user has selected this breakdown
    /// </summary>
    /// <returns></returns>
    public bool Selected { get; set; }

    public bool IsPublished { get; set; }

    public UserProfileSummaryDto CreatedBy
    {
      get
      {
        return _createdBy ?? (_createdBy = new UserProfileSummaryDto());
      }
      set
      {
        _createdBy = value;
      }
    }
  }
}