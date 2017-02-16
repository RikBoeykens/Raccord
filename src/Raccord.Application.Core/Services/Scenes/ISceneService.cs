using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Scenes
{
    // Interface for scene functionality
    public interface ISceneService : IService<SceneSummaryDto, SceneSummaryDto, SceneDto>, IAllForProjectService<SceneSummaryDto>
    {
        void Sort(SortOrderDto order);
    }
}