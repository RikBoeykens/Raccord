using System;

namespace Raccord.API.ViewModels.Users.Invitations
{
  public class UserInvitationSummaryViewModel : UserInvitationViewModel
  {
    public DateTime? AcceptedDate { get; set; }
  }
}