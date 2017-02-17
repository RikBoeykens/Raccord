namespace Raccord.Application.Core.Services.SceneProperties
{
    // Interface for int/ext functionality
    public interface IIntExtService : IService<IntExtDto, IntExtSummaryDto, FullIntExtDto>, IAllForProjectService<IntExtSummaryDto>
    {
    }
}