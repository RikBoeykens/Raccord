using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Users.Invitations.Project;

namespace Raccord.Application.Core.Services.Users.Invitations
{
  public class FullUserInvitationDto : UserInvitationDto
  {
    private IEnumerable<ProjectUserInvitationProjectDto> _projects;
    public DateTime? AcceptedDate { get; set; }        
    public IEnumerable<ProjectUserInvitationProjectDto> Projects
    {
      get
      {
          return _projects ?? new List<ProjectUserInvitationProjectDto>();
      }
      set
      {
          _projects = value;
      }
    }
  }
}