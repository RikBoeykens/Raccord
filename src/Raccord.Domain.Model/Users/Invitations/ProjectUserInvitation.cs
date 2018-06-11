using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Cast;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users.ProjectRoles;

namespace Raccord.Domain.Model.Users.Invitations
{
  public class ProjectUserInvitation : Entity<long>
  {
    private ICollection<CrewUnitInvitationMember> _crewUnitInvitationMembers;
    public long ProjectID { get; set; }

    public virtual Project Project { get; set; }
    public Guid UserInvitationID { get; set; }
    public virtual UserInvitation UserInvitation { get; set; }

    /// <summary>
    /// Role associated with the user
    /// </summary>
    /// <returns></returns>
    public long? RoleID { get; set; }

    /// <summary>
    /// Role associated with the user
    /// </summary>
    /// <returns></returns>
    public virtual ProjectRoleDefinition Role { get; set; }

    public long? CastMemberID { get; set; }
    public virtual CastMember CastMember { get;set; }

    // Crew Unit Members associated with the user
    public virtual ICollection<CrewUnitInvitationMember> CrewUnitInvitationMembers
    {
      get
      {
        return _crewUnitInvitationMembers ?? (_crewUnitInvitationMembers = new List<CrewUnitInvitationMember>());
      }
      set
      {
        _crewUnitInvitationMembers = value;
      }
    }
  }
}