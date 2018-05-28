using System;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users.ProjectRoles;

namespace Raccord.Domain.Model.Users.Invitations
{
  public class ProjectUserInvitation : Entity<long>
  {
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
  }
}