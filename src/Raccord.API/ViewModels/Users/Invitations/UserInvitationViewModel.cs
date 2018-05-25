using System;

namespace Raccord.API.ViewModels.Users.Invitations
{
  public class UserInvitationViewModel
  {
    public Guid ID { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}