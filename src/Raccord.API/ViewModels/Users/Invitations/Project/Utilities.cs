using System.Linq;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;
using Raccord.Application.Core.Services.Users.Invitations.Project;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public static class Utilities
  {
    public static FullProjectUserInvitationViewModel Translate(this FullProjectUserInvitationDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new FullProjectUserInvitationViewModel
      {
        ID = dto.ID,
        Project = dto.Project.Translate(),
        UserInvitation = dto.UserInvitation.Translate(),
        CastMember = dto.CastMember.Translate(),
        ProjectRole = dto.ProjectRole.Translate(),
        CrewUnits = dto.CrewUnits.Select(cu => cu.Translate())
      };
    }
    public static AdminFullProjectUserInvitationViewModel Translate(this AdminFullProjectUserInvitationDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new AdminFullProjectUserInvitationViewModel
      {
        ID = dto.ID,
        Project = dto.Project.Translate(),
        UserInvitation = dto.UserInvitation.Translate(),
        CastMember = dto.CastMember.Translate(),
        ProjectRole = dto.ProjectRole.Translate(),
        CrewUnits = dto.CrewUnits.Select(cu => cu.Translate())
      };
    }
    public static ProjectUserInvitationSummaryViewModel Translate(this ProjectUserInvitationSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new ProjectUserInvitationSummaryViewModel
      {
        ID = dto.ID,
        ProjectRole = dto.ProjectRole.Translate()
      };
    }
    public static ProjectUserInvitationProjectViewModel Translate(this ProjectUserInvitationProjectDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new ProjectUserInvitationProjectViewModel
      {
        ID = dto.ID,
        Project = dto.Project.Translate(),
        ProjectRole = dto.ProjectRole.Translate()
      };
    }
    public static ProjectUserInvitationUserInvitationViewModel Translate(this ProjectUserInvitationUserInvitationDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new ProjectUserInvitationUserInvitationViewModel
      {
        ID = dto.ID,
        UserInvitation = dto.UserInvitation.Translate(),
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
        ProjectID = dto.ProjectID,
        UserInvitationID = dto.UserInvitationID.ToString(),
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
        ProjectID = vm.ProjectID,
        UserInvitationID = new System.Guid(vm.UserInvitationID),
        RoleID = vm.RoleID,
      };
    }
  }
}