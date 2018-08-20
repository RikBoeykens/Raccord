using System.Collections.Generic;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class AdminFullProjectUserInvitationDto : FullProjectUserInvitationDto
  {
    private new AdminFullCastMemberDto _castMember;

    public new AdminFullCastMemberDto CastMember
    {
      get
      {
        return _castMember ?? new AdminFullCastMemberDto();
      }
      set
      {
        _castMember = value;
      }
    }
  }
}