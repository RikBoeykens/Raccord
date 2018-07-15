using System;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class ProjectUserInvitationProjectDto : ProjectUserInvitationSummaryDto
  {
    private ProjectSummaryDto _project;
    public ProjectSummaryDto Project
    {
      get
      {
        return _project ?? new ProjectSummaryDto();
      }
      set
      {
        _project = value;
      }
    }
  }
}