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
      var query = GetIncludedProject();
      return query.Where(pui => pui.UserInvitationID == invitationID);
    }

    public IEnumerable<ProjectUserInvitation> GetAllForProject(long projectID)
    {
      var query = GetIncludedUserInvitation();
      return query.Where(pui => pui.ProjectID == projectID && !pui.UserInvitation.AcceptedDate.HasValue);
    }
    public int GetCountForProject(long projectID)
    {
      var query = GetIncluded();
      return query.Count(pui => pui.ProjectID == projectID && !pui.UserInvitation.AcceptedDate.HasValue);
    }
    public int GetCountForInvitation(Guid invitationID)
    {
      var query = GetIncluded();
      return query.Count(pui => pui.UserInvitationID == invitationID);
    }

    public IEnumerable<ProjectUserInvitation> GetAllForCreateUser(Guid invitationID)
    {
      var query = GetIncludedSummaryUntracked();
      return query.Where(pui => pui.UserInvitationID == invitationID);
    }

    public ProjectUserInvitation GetFull(long ID)
    {
      var query = GetIncludedFull();
      return query.FirstOrDefault(pui => pui.ID == ID);
    }

    public ProjectUserInvitation GetSummary(long ID)
    {
      var query = GetIncludedSummary();
      return query.FirstOrDefault(pui => pui.ID == ID);
    }

    private IQueryable<ProjectUserInvitation> GetIncludedFull()
    {
      var query = _context.Set<ProjectUserInvitation>();
      return query.Include(pui => pui.Project)
                    .ThenInclude(p => p.Images)
                  .Include(pui => pui.UserInvitation)
                    .Include(pu=> pu.Role)
                      .ThenInclude(r=> r.PermissionRoles)
                        .ThenInclude(pr => pr.ProjectPermission)
                    .Include(pu => pu.CastMember)
                      .ThenInclude(cm => cm.Characters)
                        .ThenInclude(c => c.ImageCharacters)
                          .ThenInclude(ic => ic.Image)
                    .Include(pu => pu.CrewUnitInvitationMembers)
                      .ThenInclude(pu => pu.CrewUnit)
                    .Include(pu => pu.CrewUnitInvitationMembers)
                      .ThenInclude(pu => pu.CrewMembers)
                        .ThenInclude(cm => cm.Department);
    }

    private IQueryable<ProjectUserInvitation> GetIncluded()
    {
      return _context.Set<ProjectUserInvitation>();
    }

    private IQueryable<ProjectUserInvitation> GetIncludedSummary()
    {
      var query = _context.Set<ProjectUserInvitation>();
      return query.Include(pui => pui.Project)
                  .Include(pui => pui.Role)
                  .Include(pu => pu.CastMember)
                  .Include(pu => pu.CrewUnitInvitationMembers)
                    .ThenInclude(pu => pu.CrewMembers);
    }

    private IQueryable<ProjectUserInvitation> GetIncludedProject()
    {
      var query = _context.Set<ProjectUserInvitation>();
      return query.Include(pui => pui.Project)
                    .ThenInclude(p => p.Images)
                  .Include(pui => pui.Role)
                  .Include(pu => pu.CastMember)
                  .Include(pu => pu.CrewUnitInvitationMembers)
                    .ThenInclude(pu => pu.CrewMembers);
    }

    private IQueryable<ProjectUserInvitation> GetIncludedUserInvitation()
    {
      var query = _context.Set<ProjectUserInvitation>();
      return query.Include(pui => pui.UserInvitation)
                  .Include(pui => pui.Role)
                  .Include(pu => pu.CastMember)
                  .Include(pu => pu.CrewUnitInvitationMembers)
                    .ThenInclude(pu => pu.CrewMembers);
    }

    private IQueryable<ProjectUserInvitation> GetIncludedSummaryUntracked()
    {
      var query = _context.Set<ProjectUserInvitation>()
        .AsNoTracking();
      return query.Include(pui => pui.Project)
                  .Include(pui => pui.Role)
                  .Include(pu => pu.CastMember)
                  .Include(pu => pu.CrewUnitInvitationMembers)
                    .ThenInclude(pu => pu.CrewMembers);
    }
  }
}
