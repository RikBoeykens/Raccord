using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Scenes
{
    // Interface for scene functionality
    public interface ISceneService : IAllForParentService<SceneSummaryDto>
    {

        FullSceneDto Get(long ID, string userID);
        SceneSummaryDto GetSummary(long ID);

        long Add(SceneDto dto);

        long Update(SceneDto dto);

        void Delete(long ID);
        long AddByScriptUpload(SceneDto dto, long scriptUploadID);
        void Sort(SortOrderDto order);
        PagedDataDto<SceneSummaryDto> Filter(SceneFilterRequestDto dto, PaginationRequestDto requestDto);
    }
}