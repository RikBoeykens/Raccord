using Raccord.Domain.Model.Crew.CrewUnits;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members
{
    // Repository for crew units
    public class CrewUnitInvitationMemberRepository : BaseRepository<CrewUnitInvitationMember, long>, ICrewUnitInvitationMemberRepository
    {
        public CrewUnitInvitationMemberRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CrewUnitInvitationMember> GetAllForProjectUserInvitation(long projectUserInvitationID)
        {
            var query = GetIncludedUnit();

            return query.Where(s=> s.ProjectUserInvitationID == projectUserInvitationID);
        }

        private IQueryable<CrewUnitInvitationMember> GetIncludedUnit()
        {
            IQueryable<CrewUnitInvitationMember> query = _context.Set<CrewUnitInvitationMember>();

            return query.Include(cum => cum.CrewUnit)
                        .Include(cum => cum.CrewMembers)
                            .ThenInclude(cum => cum.Department)
                        .Include(cum => cum.ProjectUserInvitation)
                            .ThenInclude(cum => cum.UserInvitation);
        }
    }
}
