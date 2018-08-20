using System;

namespace Raccord.API.ViewModels.Users.Invitations
{
  public class AdminUserInvitationSummaryViewModel : UserInvitationSummaryViewModel
  {
    public int ProjectCount { get; set; }
  }
}