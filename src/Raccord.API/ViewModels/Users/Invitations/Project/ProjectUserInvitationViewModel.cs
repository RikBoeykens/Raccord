using System;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public class ProjectUserInvitationViewModel
  {
    public long ID { get; set; }
    public Guid UserInvitationID { get; set; }
    public long ProjectID { get; set; }
    public long? RoleID { get; set; }
  }
}