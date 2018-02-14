using System.Linq;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;
using Raccord.API.ViewModels.Profile;
using Raccord.Application.Core.Services.Breakdowns;

namespace Raccord.API.ViewModels.Breakdowns
{
  public static class Utilities
  {
    public static FullBreakdownViewModel Translate(this FullBreakdownDto dto)
    {
      if(dto==null)
      {
        return null;
      }

      return new FullBreakdownViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        Types = dto.Types.Select(t=> t.Translate()),
      };
    }
    public static BreakdownSummaryViewModel Translate(this BreakdownSummaryDto dto)
    {
      if(dto==null)
      {
        return null;
      }

      return new BreakdownSummaryViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        CreatedBy = dto.CreatedBy.Translate(),
        Selected = dto.Selected,
        IsPublished = dto.IsPublished,
        IsDefault = dto.IsDefault
      };
    }
    public static BreakdownViewModel Translate(this BreakdownDto dto)
    {
      if(dto==null)
      {
        return null;
      }

      return new BreakdownViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
      };
    }
    public static LinkedBreakdownViewModel Translate(this LinkedBreakdownDto dto)
    {
      if(dto==null)
      {
        return null;
      }

      return new LinkedBreakdownViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        UserID = dto.UserID,
        Items = dto.Items.Select(i=> i.Translate()),
        Types = dto.Types.Select(t=> t.Translate())
      };
    }
    public static CallsheetBreakdownViewModel Translate(this CallsheetBreakdownDto dto)
    {
      if(dto==null)
      {
        return null;
      }

      return new CallsheetBreakdownViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        Types = dto.Types.Select(t=> t.Translate())
      };
    }
    public static BreakdownDto Translate(this BreakdownViewModel vm, string userID)
    {
      if(vm==null)
      {
        return null;
      }

      return new BreakdownDto
      {
        ID = vm.ID,
        Name = vm.Name,
        Description = vm.Description,
        ProjectID = vm.ProjectID,
        UserID = userID
      };
    }
  }
}