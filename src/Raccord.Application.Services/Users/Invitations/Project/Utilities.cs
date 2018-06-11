using System.Linq;
using Raccord.Application.Core.Services.Users.Invitations.Project;
using Raccord.Application.Services.Cast;
using Raccord.Application.Services.Crew.CrewUnits;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Users.ProjectRoles;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Application.Services.Users.Invitations.Project
{
  public static class Utilities
  {
    public static FullProjectUserInvitationDto TranslateFull(this ProjectUserInvitation projectUserInvitation)
    {
      if(projectUserInvitation == null)
      {
        return null;
      }
      return new FullProjectUserInvitationDto
      {
        ID = projectUserInvitation.ID,
        UserInvitation = projectUserInvitation.UserInvitation.Translate(),
        Project = projectUserInvitation.Project.Translate(),
        CastMember = projectUserInvitation.CastMember.Translate(),
        ProjectRole = projectUserInvitation.Role.Translate(),
        CrewUnits = projectUserInvitation.CrewUnitInvitationMembers.Select(cum => cum.TranslateCrewUnit())
      };
    }
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