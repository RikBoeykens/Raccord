using System;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public interface IProjectUserInvitationService
  {
    IEnumerable<ProjectUserInvitationSummaryDto> GetProjects(Guid invitationID);
    FullProjectUserInvitationDto Get(long ID);
    ProjectUserInvitationSummaryDto GetSummary(long ID);
    long Add(ProjectUserInvitationDto dto);
    long Update(ProjectUserInvitationDto dto);
    void Delete(long ID);
  }
}