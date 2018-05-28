using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects
{
  // Repository for user invitations
  public class ProjectUserInvitationRepository : BaseRepository<ProjectUserInvitation, long>, IProjectUserInvitationRepository
  {
    public ProjectUserInvitationRepository(RaccordDBContext context) : base(context) 
    {
    }

    public IEnumerable<ProjectUserInvitation> GetAllForInvitation(Guid invitationID)
    {
      var query = GetIncludedSummary();
      return query.Where(pui => pui.UserInvitationID == invitationID);
    }

    public ProjectUserInvitation GetSummary(long ID)
    {
      var query = GetIncludedSummary();
      return query.FirstOrDefault(pui => pui.ID == ID);
    }

    private IQueryable<ProjectUserInvitation> GetIncludedSummary()
    {
      var query = _context.Set<ProjectUserInvitation>();
      return query.Include(pui => pui.Project)
                  .Include(pui => pui.Role);
    }
  }
}
