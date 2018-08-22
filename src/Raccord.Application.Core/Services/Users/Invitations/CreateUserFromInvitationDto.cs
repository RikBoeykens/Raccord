using System;

namespace Raccord.Application.Core.Services.Users.Invitations
{
  public class CreateUserFromInvitationDto
  {
    public Guid ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}