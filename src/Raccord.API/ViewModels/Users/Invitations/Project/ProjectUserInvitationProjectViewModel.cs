using System;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public class ProjectUserInvitationProjectViewModel : ProjectUserInvitationSummaryViewModel
  {
    private ProjectViewModel _project;
    public ProjectViewModel Project
    {
      get
      {
        return _project ?? new ProjectViewModel();
      }
      set
      {
        _project = value;
      }
    }
  }
}