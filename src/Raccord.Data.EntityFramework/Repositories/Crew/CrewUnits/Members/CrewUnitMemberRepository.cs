using Raccord.Domain.Model.Crew.CrewUnits;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members
{
    // Repository for crew units
    public class CrewUnitMemberRepository : BaseRepository<CrewUnitMember, long>, ICrewUnitMemberRepository
    {
        public CrewUnitMemberRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CrewUnitMember> GetAllForUnit(long unitID)
        {
            var query = GetIncludedProjectUser();

            return query.Where(s=> s.CrewUnitID == unitID);
        }

        public IEnumerable<CrewUnitMember> GetAllForProjectUser(long projectUserID)
        {
            var query = GetIncludedUnit();

            return query.Where(s=> s.ProjectUserID == projectUserID);
        }

        private IQueryable<CrewUnitMember> GetIncludedProjectUser()
        {
            IQueryable<CrewUnitMember> query = _context.Set<CrewUnitMember>();

            return query.Include(cum => cum.ProjectUser)
                            .ThenInclude(pu => pu.User)
                        .Include(cum => cum.ProjectUser)
                            .ThenInclude(pu => pu.Role);
        }

        private IQueryable<CrewUnitMember> GetIncludedUnit()
        {
            IQueryable<CrewUnitMember> query = _context.Set<CrewUnitMember>();

            return query.Include(cum => cum.CrewUnit)
                        .Include(cum => cum.CrewMembers)
                            .ThenInclude(cum => cum.Department)
                        .Include(cum => cum.ProjectUser)
                            .ThenInclude(cum => cum.User);
        }
    }
}
