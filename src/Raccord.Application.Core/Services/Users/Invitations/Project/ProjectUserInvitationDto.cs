using System;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class ProjectUserInvitationDto
  {
    public long ID { get; set; }
    public Guid UserInvitationID { get; set; }
    public long ProjectID { get; set; }
    public long? RoleID { get; set; }
  }
}