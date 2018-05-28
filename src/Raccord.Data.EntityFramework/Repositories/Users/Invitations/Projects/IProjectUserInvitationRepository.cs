using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects
{
  // Interface defining a repository for UserInvitations
  public interface IProjectUserInvitationRepository : IBaseRepository<ProjectUserInvitation, long>
  {
    IEnumerable<ProjectUserInvitation> GetAllForInvitation(Guid invitationID);
    ProjectUserInvitation GetSummary(long ID);
  }
}