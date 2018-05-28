using System;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Data.EntityFramework.Repositories.Users.Invitations
{
  // Interface defining a repository for UserInvitations
  public interface IUserInvitationRepository : IBaseRepository<UserInvitation, Guid>
  {
    UserInvitation GetFull(Guid ID);
  }
}