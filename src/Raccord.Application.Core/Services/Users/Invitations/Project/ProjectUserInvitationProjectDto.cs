using System;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class ProjectUserInvitationProjectDto : ProjectUserInvitationSummaryDto
  {
    private ProjectDto _project;
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