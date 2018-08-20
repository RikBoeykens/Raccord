using System;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public class ProjectUserInvitationUserInvitationViewModel : ProjectUserInvitationSummaryViewModel
  {
    private UserInvitationViewModel _invitation;
    public UserInvitationViewModel UserInvitation
    {
      get
      {
        return _invitation ?? new UserInvitationViewModel();
      }
      set
      {
        _invitation = value;
      }
    }
  }
}