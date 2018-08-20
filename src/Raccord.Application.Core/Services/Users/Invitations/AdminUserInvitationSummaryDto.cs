using System;

namespace Raccord.Application.Core.Services.Users.Invitations
{
  public class AdminUserInvitationSummaryDto : UserInvitationSummaryDto
  {
    public int ProjectCount { get; set; }
  }
}