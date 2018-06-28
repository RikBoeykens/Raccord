using System;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class ProjectUserInvitationUserInvitationDto : ProjectUserInvitationSummaryDto
  {
    private UserInvitationDto _userInvitation;
    public UserInvitationDto UserInvitation
    {
      get
      {
        return _userInvitation ?? new UserInvitationDto();
      }
      set
      {
        _userInvitation = value;
      }
    }
  }
}