using System;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class ProjectUserInvitationSummaryDto
  {
    private ProjectRoleDto _role;
    private ProjectDto _project;
    public long ID { get; set; }
    public ProjectRoleDto ProjectRole
    {
      get
      {
        return _role ?? new ProjectRoleDto();
      }
      set
      {
        _role = value;
      }
    }
    public ProjectDto Project
    {
      get
      {
        return _project ?? new ProjectDto();
      }
      set
      {
        _project = value;
      }
    }
  }
}