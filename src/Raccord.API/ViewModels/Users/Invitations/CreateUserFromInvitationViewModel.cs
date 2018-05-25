using System;

namespace Raccord.API.ViewModels.Users.Invitations
{
  public class CreateUserFromInvitationViewModel
  {
    public Guid ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
  }
}