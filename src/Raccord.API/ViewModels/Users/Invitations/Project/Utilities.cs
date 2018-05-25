using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;
using Raccord.Application.Core.Services.Users.Invitations.Project;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public static class Utilities
  {
    public static ProjectUserInvitationSummaryViewModel Translate(this ProjectUserInvitationSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new ProjectUserInvitationSummaryViewModel
      {
        ID = dto.ID,
        Project = dto.Project.Translate(),
        ProjectRole = dto.ProjectRole.Translate()
      };
    }

    public static ProjectUserInvitationViewModel Translate(this ProjectUserInvitationDto dto)
    {
      if (dto == null)
      {
        return null;
      }

      return new ProjectUserInvitationViewModel
      {
        ID = dto.ID,
        UserInvitationID = dto.UserInvitationID,
        RoleID = dto.RoleID,
      };
    }

    public static ProjectUserInvitationDto Translate(this ProjectUserInvitationViewModel vm)
    {
      if (vm == null)
      {
        return null;
      }

      return new ProjectUserInvitationDto
      {
        ID = vm.ID,
        UserInvitationID = vm.UserInvitationID,
        RoleID = vm.RoleID,
      };
    }
  }
}