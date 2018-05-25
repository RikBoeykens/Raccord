using System.Linq;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.Application.Services.Users.Invitations.Project;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Application.Services.Users.Invitations
{
  public static class Utilities
  {
    public static FullUserInvitationDto TranslateFull(this UserInvitation userInvitation)
    {
      if(userInvitation == null)
      {
        return null;
      }

      return new FullUserInvitationDto
      {
        ID = userInvitation.ID,
        Email = userInvitation.Email,
        FirstName = userInvitation.FirstName,
        LastName = userInvitation.LastName,
        AcceptedDate = userInvitation.AcceptedDate,
        Projects = userInvitation.ProjectUsers.Select(pu => pu.Translate())
      };
    }

    public static UserInvitationSummaryDto TranslateSummary(this UserInvitation userInvitation)
    {
      if(userInvitation == null)
      {
        return null;
      }

      return new UserInvitationSummaryDto
      {
        ID = userInvitation.ID,
        Email = userInvitation.Email,
        FirstName = userInvitation.FirstName,
        LastName = userInvitation.LastName,
        AcceptedDate = userInvitation.AcceptedDate,
      };
    }

    public static UserInvitationDto Translate(this UserInvitation userInvitation)
    {
      if(userInvitation == null)
      {
        return null;
      }

      return new UserInvitationDto
      {
        ID = userInvitation.ID,
        Email = userInvitation.Email,
        FirstName = userInvitation.FirstName,
        LastName = userInvitation.LastName,
      };
    }
  }
}