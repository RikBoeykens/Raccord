using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes
{
    // Interface defining a repository for Call type definitions
    public interface ICallTypeDefinitionRepository : IBaseRepository<CallTypeDefinition, long>
    {
    }
}