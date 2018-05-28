using System;

namespace Raccord.Application.Core.Services.Users.Invitations
{
  public class UserInvitationSummaryDto : UserInvitationDto
  {
    public DateTime? AcceptedDate { get; set; }
  }
}