using System;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public class ProjectUserInvitationProjectViewModel : ProjectUserInvitationSummaryViewModel
  {
    private ProjectSummaryViewModel _project;
    public ProjectSummaryViewModel Project
    {
      get
      {
        return _project ?? new ProjectSummaryViewModel();
      }
      set
      {
        _project = value;
      }
    }
  }
}