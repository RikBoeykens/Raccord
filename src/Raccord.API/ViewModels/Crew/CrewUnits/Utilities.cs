using System.Linq;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Crew.CrewUnits
{
  public static class Utilities
  {
    public static FullCrewUnitViewModel Translate(this FullCrewUnitDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new FullCrewUnitViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID
      };
    }
    public static FullAdminCrewUnitViewModel Translate(this FullAdminCrewUnitDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new FullAdminCrewUnitViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        ProjectUsers = dto.ProjectUsers.Select(p => p.Translate())
      };
    }
    public static CrewUnitSummaryViewModel Translate(this CrewUnitSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new CrewUnitSummaryViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID
      };
    }
    public static CrewUnitViewModel Translate(this CrewUnitDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new CrewUnitViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID
      };
    }
    public static LinkedCrewUnitViewModel Translate(this LinkedCrewUnitDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new LinkedCrewUnitViewModel
      {
        ID = dto.ID,
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        LinkID = dto.LinkID,
      };
    }
    public static CrewUnitDto Translate(this CrewUnitViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }

      return new CrewUnitDto
      {
        ID = vm.ID,
        Name = vm.Name,
        Description = vm.Description,
        ProjectID = vm.ProjectID
      };
    }
  }
}