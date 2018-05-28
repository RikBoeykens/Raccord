using System.Collections.Generic;
using Raccord.Domain.Model.Crew.Departments;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Crew.CrewUnits
{
    /// Represents a unit of crew
    public class CrewUnit : Entity<long>
    {
      private ICollection<CrewUnitMember> _members;
      private ICollection<CrewDepartment> _departments;
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

      public virtual ICollection<CrewDepartment> CrewDepartments
      {
        get
        {
          return _departments ?? (_departments = new List<CrewDepartment>());
        }
        set
        {
          _departments = value;
        }
      }
    }
}