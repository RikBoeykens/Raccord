using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes
{
    // Repository for call types
    public class CallTypeRepository : BaseRepository<CallType, long>, ICallTypeRepository
    {
        public CallTypeRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CallType> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(l=> l.ProjectID == projectID);
        }
        private IQueryable<CallType> GetIncludedSummary()
        {
            IQueryable<CallType> query = _context.Set<CallType>();

            return query.Include(bt=> bt.CharacterCalls);
        }
    }
}
