using Raccord.Application.Core.Services.Users.Invitations.Project;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Users.ProjectRoles;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Application.Services.Users.Invitations.Project
{
  public static class Utilities
  {
    public static ProjectUserInvitationSummaryDto Translate(this ProjectUserInvitation projectUserInvitation)
    {
      if(projectUserInvitation == null)
      {
        return null;
      }
      return new ProjectUserInvitationSummaryDto
      {
        ID = projectUserInvitation.ID,
        Project = projectUserInvitation.Project.Translate(),
        ProjectRole = projectUserInvitation.Role.Translate(),
      };
    }
  }
}