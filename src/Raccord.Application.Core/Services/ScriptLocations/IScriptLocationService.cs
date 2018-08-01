using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.ScriptLocations
{
    // Interface for location functionality
    public interface IScriptLocationService : IService<ScriptLocationDto, ScriptLocationSummaryDto, FullScriptLocationDto>, IAllForParentService<ScriptLocationSummaryDto>
    {
        PagedDataDto<ScriptLocationSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId);
        void Merge(long toID, long mergeID);
    }
}