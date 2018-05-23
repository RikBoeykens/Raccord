using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes
{
    // Repository for breakdown type definitions
    public class CallTypeDefinitionRepository : BaseRepository<CallTypeDefinition, long>, ICallTypeDefinitionRepository
    {
        public CallTypeDefinitionRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
