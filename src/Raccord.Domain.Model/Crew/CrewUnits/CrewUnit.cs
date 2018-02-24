using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Crew.CrewUnits
{
    /// Represents a unit of crew
    public class CrewUnit : Entity
    {
      public string Name { get;set;}

      public string Description { get;set; }

      public long ProjectID { get;set; }

      public virtual Project Project { get; set; }
    }
}