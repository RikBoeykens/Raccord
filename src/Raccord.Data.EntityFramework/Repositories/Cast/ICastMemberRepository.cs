using Raccord.Domain.Model.Cast;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Cast
{
    // Interface defining a repository for Cast Members
    public interface ICastMemberRepository : IBaseRepository<CastMember>
    {
        IEnumerable<CastMember> GetAllForProject(long projectID);
        CastMember GetFull(long ID);
        CastMember GetSummary(long ID);
    }
}