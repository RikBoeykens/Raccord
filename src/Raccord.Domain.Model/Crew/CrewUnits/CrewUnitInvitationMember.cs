using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Domain.Model.Crew.CrewUnits
{
    /// Represents a unit of crew
    public class CrewUnitInvitationMember : Entity<long>
    {
      private ICollection<CrewMember> _crewMembers;
      public long CrewUnitID { get; set; }
      public virtual CrewUnit CrewUnit { get; set; }
      public long ProjectUserInvitationID { get; set; }
      public virtual ProjectUserInvitation ProjectUserInvitation { get; set; }

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