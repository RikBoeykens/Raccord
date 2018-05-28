using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewUnits;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members
{
    // Interface defining a repository for crew units
    public interface ICrewUnitMemberRepository : IBaseRepository<CrewUnitMember, long>
    {
        IEnumerable<CrewUnitMember> GetAllForUnit(long unitID);
        IEnumerable<CrewUnitMember> GetAllForProjectUser(long projectUserID);
    }
}