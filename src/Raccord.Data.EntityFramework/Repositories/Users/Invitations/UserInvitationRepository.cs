using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Data.EntityFramework.Repositories.Users.Invitations
{
  // Repository for user invitations
  public class UserInvitationRepository : BaseRepository<UserInvitation, Guid>, IUserInvitationRepository
  {
    public UserInvitationRepository(RaccordDBContext context) : base(context) 
    {
    }

    public UserInvitation GetFull(Guid ID)
    {
      var query = GetIncludedFull();

      return query.FirstOrDefault(ui => ui.ID == ID);
    }

    private IQueryable<UserInvitation> GetIncludedFull()
    {
      var query = _context.Set<UserInvitation>();

      return query.Include(ui => ui.ProjectUserInvitations)
                    .ThenInclude(pu => pu.Project)
                  .Include(ui => ui.ProjectUserInvitations)
                    .ThenInclude(pu => pu.Role);
    }
  }
}
