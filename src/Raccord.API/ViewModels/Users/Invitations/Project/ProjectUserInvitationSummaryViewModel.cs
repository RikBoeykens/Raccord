using System;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public class ProjectUserInvitationSummaryViewModel
  {
    private ProjectRoleViewModel _role;
    private ProjectViewModel _project;
    public long ID { get; set; }
    public ProjectRoleViewModel ProjectRole
    {
      get
      {
        return _role ?? new ProjectRoleViewModel();
      }
      set
      {
        _role = value;
      }
    }
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