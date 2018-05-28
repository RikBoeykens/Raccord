using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Users.Invitations.Project;

namespace Raccord.Application.Core.Services.Users.Invitations
{
  public class FullUserInvitationDto : UserInvitationDto
  {
    private IEnumerable<ProjectUserInvitationSummaryDto> _projects;
    public DateTime? AcceptedDate { get; set; }        
    public IEnumerable<ProjectUserInvitationSummaryDto> Projects
    {
      get
      {
          return _projects ?? new List<ProjectUserInvitationSummaryDto>();
      }
      set
      {
          _projects = value;
      }
    }
  }
}