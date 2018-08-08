using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Interface for location functionality
    public interface ILocationService : IService<LocationDto, LocationSummaryDto, FullLocationDto>, IAllForParentService<LocationSummaryDto>
    {
        PagedDataDto<LocationSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId);
    }
}