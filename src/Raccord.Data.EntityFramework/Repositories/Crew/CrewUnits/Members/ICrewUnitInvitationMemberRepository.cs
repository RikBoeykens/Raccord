using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewUnits;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members
{
    // Interface defining a repository for crew units
    public interface ICrewUnitInvitationMemberRepository : IBaseRepository<CrewUnitInvitationMember, long>
    {
        IEnumerable<CrewUnitInvitationMember> GetAllForProjectUserInvitation(long projectUserInvitationID);
    }
}