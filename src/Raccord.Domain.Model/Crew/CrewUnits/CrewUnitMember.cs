using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Crew.CrewUnits
{
    /// Represents a unit of crew
    public class CrewUnitMember : Entity
    {
      public long CrewUnitID { get; set; }
      public virtual CrewUnit CrewUnit { get; set; }

      public long ProjectUserID { get; set; }
      public virtual ProjectUser ProjectUser { get; set; }
    }
}