using System;
using System.Linq;
using Raccord.Application.Core.Common.Routing;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.Application.Services.Users.Invitations.Project;
using Raccord.Core.Enums;
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
        Projects = userInvitation.ProjectUserInvitations.Select(pu => pu.TranslateProject())
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

    public static SearchResultDto TranslateToSearchResult(this UserInvitation userInvitation)
    {
    var dto = new SearchResultDto
    {
      ID = userInvitation.ID,
      DisplayName = $"{userInvitation.FirstName} {userInvitation.LastName}",
      RouteInfo = new RouteInfoDto
      {
        RouteIDs = new object[]{userInvitation.ID},
        Type = EntityType.User,
      }
    };
    return dto;
    }
  }
}