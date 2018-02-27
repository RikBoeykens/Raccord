using System.Collections.Generic;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Crew.CrewUnits
{
    /// Represents a unit of crew
    public class CrewUnit : Entity
    {
      private ICollection<CrewUnitMember> _members;
      public string Name { get;set;}

      public string Description { get;set; }

      public long ProjectID { get;set; }

      public virtual Project Project { get; set; }

      public virtual ICollection<CrewUnitMember> CrewUnitMembers
      {
        get
        {
          return _members ?? (_members = new List<CrewUnitMember>());
        }
        set
        {
          _members = value;
        }
      }
    }
}