using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.Users.Invitations.Project;

namespace Raccord.API.ViewModels.Users.Invitations
{
  public class FullUserInvitationViewModel : UserInvitationViewModel
  {
    private IEnumerable<ProjectUserInvitationSummaryViewModel> _projects;
    public DateTime? AcceptedDate { get; set; }        
    public IEnumerable<ProjectUserInvitationSummaryViewModel> Projects
    {
      get
      {
        return _projects ?? new List<ProjectUserInvitationSummaryViewModel>();
      }
      set
      {
        _projects = value;
      }
    }
  }
}