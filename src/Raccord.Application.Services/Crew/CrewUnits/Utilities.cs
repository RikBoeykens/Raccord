using System.Linq;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Services.Users.Projects;
using Raccord.Domain.Model.Crew.CrewUnits;

namespace Raccord.Application.Services.Crew.CrewUnits
{
  public static class Utilities
  {
    public static FullCrewUnitDto TranslateFull(this CrewUnit crewUnit)
    {
      if(crewUnit == null)
      {
        return null;
      }

      return new FullCrewUnitDto
      {
        ID = crewUnit.ID,
        Name = crewUnit.Name,
        Description = crewUnit.Description,
        ProjectID = crewUnit.ProjectID,
      };
    }
    public static FullAdminCrewUnitDto TranslateFullAdmin(this CrewUnit crewUnit)
    {
      if(crewUnit == null)
      {
        return null;
      }

      return new FullAdminCrewUnitDto
      {
        ID = crewUnit.ID,
        Name = crewUnit.Name,
        Description = crewUnit.Description,
        ProjectID = crewUnit.ProjectID,
        ProjectUsers = crewUnit.CrewUnitMembers.Select(c => c.TranslateProjectUser())
      };
    }

    public static CrewUnitSummaryDto TranslateSummary(this CrewUnit crewUnit)
    {
      if(crewUnit == null)
      {
        return null;
      }

      return new CrewUnitSummaryDto
      {
        ID = crewUnit.ID,
        Name = crewUnit.Name,
        Description = crewUnit.Description,
        ProjectID = crewUnit.ProjectID
      };
    }

    public static CrewUnitDto Translate(this CrewUnit crewUnit)
    {
      if(crewUnit == null)
      {
        return null;
      }

      return new CrewUnitDto
      {
        ID = crewUnit.ID,
        Name = crewUnit.Name,
        Description = crewUnit.Description,
        ProjectID = crewUnit.ProjectID
      };
    }

    public static LinkedCrewUnitDto TranslateCrewUnit(this CrewUnitMember crewUnitMember)
    {
      if(crewUnitMember == null || crewUnitMember.CrewUnit == null)
      {
        return null;
      }

      return new LinkedCrewUnitDto
      {
        ID = crewUnitMember.CrewUnit.ID,
        Name = crewUnitMember.CrewUnit.Name,
        Description = crewUnitMember.CrewUnit.Description,
        ProjectID = crewUnitMember.CrewUnit.ProjectID,
        LinkID = crewUnitMember.ID
      };
    }
  }
}