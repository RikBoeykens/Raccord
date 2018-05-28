using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes
{
    // Interface defining a repository for Breakdown type definitions
    public interface IBreakdownTypeDefinitionRepository : IBaseRepository<BreakdownTypeDefinition, long>
    {
    }
}