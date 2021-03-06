using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects
{
  // Interface defining a repository for UserInvitations
  public interface IProjectUserInvitationRepository : IBaseRepository<ProjectUserInvitation, long>
  {
    IEnumerable<ProjectUserInvitation> GetAllForInvitation(Guid invitationID);
    IEnumerable<ProjectUserInvitation> GetAllForProject(long projectID);
    int GetCountForProject(long projectID);
    int GetCountForInvitation(Guid invitationID);
    IEnumerable<ProjectUserInvitation> GetAllForCreateUser(Guid invitationID);
    ProjectUserInvitation GetFull(long ID);
    ProjectUserInvitation GetSummary(long ID);
  }
}