using System;
using System.Collections.Generic;
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

    public IEnumerable<UserInvitation> GetAllAdmin()
    {
      var query = GetIncludedAdminSummary();

      return query;
    }

    public int SearchCount(string searchText, string userID, Guid[] excludeIds)
    {
        var query = GetSearchQuery(searchText, userID, excludeIds);

        return query.Count();        
    }

    public IEnumerable<UserInvitation> Search(string searchText, string userID, Guid[] excludeIds)
    {
        return GetSearchQuery(searchText, userID, excludeIds);
    }

    private IQueryable<UserInvitation> GetIncludedFull()
    {
      var query = _context.Set<UserInvitation>();

      return query.Include(ui => ui.ProjectUserInvitations)
                    .ThenInclude(pu => pu.Project)
                  .Include(ui => ui.ProjectUserInvitations)
                    .ThenInclude(pu => pu.Role);
    }

    private IQueryable<UserInvitation> GetIncludedAdminSummary()
    {
      var query = _context.Set<UserInvitation>();

      return query.Include(ui => ui.ProjectUserInvitations);
    }

    private IQueryable<UserInvitation> GetSearchQuery(string searchText, string userId, Guid[] excludeIds)
    {
      var query = GetIncludedSearch();

      query = query.Where(u=> u.FirstName.ToLower().Contains(searchText.ToLower())
                          ||
                          u.LastName.ToLower().Contains(searchText.ToLower())
                          ||
                          u.Email.ToLower().Contains(searchText.ToLower()));

      if(excludeIds.Any())
      {
        query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
      }

      return query;
    }

    private IQueryable<UserInvitation> GetIncludedSearch()
    {
      IQueryable<UserInvitation> query = _context.Set<UserInvitation>();

      return query;
    }
  }
}
