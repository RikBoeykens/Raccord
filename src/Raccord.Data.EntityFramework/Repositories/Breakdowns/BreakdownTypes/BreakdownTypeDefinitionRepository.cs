using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes
{
    // Repository for breakdown type definitions
    public class BreakdownTypeDefinitionRepository : BaseRepository<BreakdownTypeDefinition>, IBreakdownTypeDefinitionRepository
    {
        public BreakdownTypeDefinitionRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
