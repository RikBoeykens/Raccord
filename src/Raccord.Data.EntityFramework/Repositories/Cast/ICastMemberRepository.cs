using Raccord.Domain.Model.Cast;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Cast
{
    // Interface defining a repository for Cast Members
    public interface ICastMemberRepository : IBaseRepository<CastMember, long>
    {
        IEnumerable<CastMember> GetAllForProject(long projectID);
        CastMember GetFull(long ID);
        CastMember GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<CastMember> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}