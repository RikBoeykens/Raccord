using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes
{
    // Interface defining a repository for Call type
    public interface ICallTypeRepository : IBaseRepository<CallType>
    {
        IEnumerable<CallType> GetAllForProject(long projectID);
    }
}