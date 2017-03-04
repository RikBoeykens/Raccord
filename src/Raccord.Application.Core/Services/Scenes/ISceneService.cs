using System.Collections.Generic;
using Raccord.Application.Core.Common.Sorting;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Scenes
{
    // Interface for scene functionality
    public interface ISceneService : IService<SceneDto, SceneSummaryDto, FullSceneDto>, IAllForProjectService<SceneSummaryDto>
    {
        void Sort(SortOrderDto order);

        IEnumerable<LinkedImageDto> GetImages(long ID);
    }
}