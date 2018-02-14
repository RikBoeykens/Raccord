using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
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
        Selected = breakdown.SelectedByUsers.Any(sbu=> sbu.UserID == userID),
        IsPublished = breakdown.IsPublished,
        IsDefault = breakdown.IsDefaultProjectBreakdown
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
        ProjectID = breakdown.ProjectID,
      };
    }
    public static LinkedBreakdownDto TranslateLinked(this Breakdown breakdown, IEnumerable<LinkedBreakdownItemDto> items)
    {
      if(breakdown == null)
      {
        return null;
      }

      return new LinkedBreakdownDto
      {
        ID = breakdown.ID,
        Name = breakdown.Name,
        Description = breakdown.Description,
        ProjectID = breakdown.ProjectID,
        UserID = breakdown.UserID,
        Items = items,
        Types = breakdown.Types.Select(t=> t.Translate())
      };
    }
    public static CallsheetBreakdownDto TranslateCallsheet(this Breakdown breakdown, IEnumerable<CallsheetBreakdownTypeDto> types)
    {
      if(breakdown == null)
      {
        return null;
      }

      return new CallsheetBreakdownDto
      {
        ID = breakdown.ID,
        Name = breakdown.Name,
        Description = breakdown.Description,
        ProjectID = breakdown.ProjectID,
        Types = types
      };
    }
  }
}