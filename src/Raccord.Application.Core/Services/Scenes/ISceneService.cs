using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Scenes
{
    // Interface for scene functionality
    public interface ISceneService : IService<SceneDto, SceneSummaryDto, FullSceneDto>, IAllForParentService<SceneSummaryDto>
    {
        long AddByScriptUpload(SceneDto dto, long scriptUploadID);
        void Sort(SortOrderDto order);
        PagedDataDto<SceneSummaryDto> Filter(SceneFilterRequestDto dto, PaginationRequestDto requestDto);
    }
}