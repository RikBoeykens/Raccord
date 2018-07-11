using System.Linq;
using Raccord.API.ViewModels.Users.Invitations.Project;
using Raccord.Application.Core.Services.Users.Invitations;

namespace Raccord.API.ViewModels.Users.Invitations
{
  public static class Utilities
  {
    public static FullUserInvitationViewModel Translate(this FullUserInvitationDto dto)
    {
      if(dto == null)
      {
        return null;
      }
      return new FullUserInvitationViewModel
      {
        ID = dto.ID,
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        AcceptedDate = dto.AcceptedDate,
        Projects = dto.Projects.Select(p => p.Translate())
      };
    }
    public static AdminFullUserInvitationViewModel Translate(this AdminFullUserInvitationDto dto)
    {
      if(dto == null)
      {
        return null;
      }
      return new AdminFullUserInvitationViewModel
      {
        ID = dto.ID,
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        AcceptedDate = dto.AcceptedDate,
        Projects = dto.Projects.Select(p => p.Translate())
      };
    }
    public static UserInvitationSummaryViewModel Translate(this UserInvitationSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }
      return new UserInvitationSummaryViewModel
      {
        ID = dto.ID,
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        AcceptedDate = dto.AcceptedDate,
      };
    }
    public static AdminUserInvitationSummaryViewModel Translate(this AdminUserInvitationSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }
      return new AdminUserInvitationSummaryViewModel
      {
        ID = dto.ID,
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        AcceptedDate = dto.AcceptedDate,
      };
    }
    public static UserInvitationViewModel Translate(this UserInvitationDto dto)
    {
      if(dto == null)
      {
        return null;
      }
      return new UserInvitationViewModel
      {
        ID = dto.ID,
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
      };
    }
    public static UserInvitationDto Translate(this UserInvitationViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }
      return new UserInvitationDto
      {
        ID = vm.ID,
        Email = vm.Email,
        FirstName = vm.FirstName,
        LastName = vm.LastName,
      };
    }
    public static CreateUserFromInvitationDto Translate(this CreateUserFromInvitationViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }
      return new CreateUserFromInvitationDto
      {
        ID = vm.ID,
        FirstName = vm.FirstName,
        LastName = vm.LastName,
        Password = vm.Password
      };
    }
  }
}