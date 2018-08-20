using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Data.EntityFramework.Repositories.Users.Invitations
{
  // Interface defining a repository for UserInvitations
  public interface IUserInvitationRepository : IBaseRepository<UserInvitation, Guid>
  {
    UserInvitation GetFull(Guid ID);
    int SearchCount(string searchText, string userID, Guid[] excludeIds);
    IEnumerable<UserInvitation> Search(string searchText, string userID, Guid[] excludeIds);
    IEnumerable<UserInvitation> GetAllAdmin();
  }
}