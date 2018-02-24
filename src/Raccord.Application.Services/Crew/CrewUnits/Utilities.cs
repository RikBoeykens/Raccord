using Raccord.Application.Core.Services.Crew.CrewUnits;
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
        ProjectID = crewUnit.ProjectID
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
  }
}