using Raccord.Application.Core.Services.Profile;

namespace Raccord.Application.Core.Services.Breakdowns
{
  public class BreakdownSummaryDto: BaseBreakdownDto
  {
    private UserProfileSummaryDto _createdBy;

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