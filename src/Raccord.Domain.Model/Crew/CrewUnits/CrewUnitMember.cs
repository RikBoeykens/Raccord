using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Crew.CrewUnits
{
    /// Represents a unit of crew
    public class CrewUnitMember : Entity<long>
    {
      private ICollection<CrewMember> _crewMembers;
      public long CrewUnitID { get; set; }
      public virtual CrewUnit CrewUnit { get; set; }

      public long ProjectUserID { get; set; }
      public virtual ProjectUser ProjectUser { get; set; }

      public virtual ICollection<CrewMember> CrewMembers
      {
        get
        {
          return _crewMembers ?? (_crewMembers = new List<CrewMember>());
        }
        set
        {
          _crewMembers = value;
        }
      }
    }
}