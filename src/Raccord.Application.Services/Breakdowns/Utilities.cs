using System.Linq;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Application.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Services.Profile;
using Raccord.Domain.Model.Breakdowns;

namespace Raccord.Application.Services.Breakdowns
{
  public static class Utilities
  {
    public static FullBreakdownDto TranslateFull(this Breakdown breakdown)
    {
      if(breakdown == null)
      {
        return null;
      }

      return new FullBreakdownDto
      {
        ID = breakdown.ID,
        Name = breakdown.Name,
        Description = breakdown.Description,
        ProjectID = breakdown.ProjectID,
        Types = breakdown.Types.Select(t => t.TranslateSummary())
      };
    }
    public static BreakdownSummaryDto TranslateSummary(this Breakdown breakdown, string userID = null)
    {
      if(breakdown == null)
      {
        return null;
      }

      return new BreakdownSummaryDto
      {
        ID = breakdown.ID,
        Name = breakdown.Name,
        Description = breakdown.Description,
        CreatedBy = breakdown.User.TranslateSummary(),
        ProjectID = breakdown.ProjectID,
        Selected = breakdown.SelectedByUsers.Any(sbu=> sbu.UserID == userID)
      };
    }
    public static BreakdownDto Translate(this Breakdown breakdown)
    {
      if(breakdown == null)
      {
        return null;
      }

      return new BreakdownDto
      {
        ID = breakdown.ID,
        Name = breakdown.Name,
        Description = breakdown.Description,
        ProjectID = breakdown.ProjectID
      };
    }
  }
}