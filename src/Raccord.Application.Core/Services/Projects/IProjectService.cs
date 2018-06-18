using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Projects
{
    // Interface for project functionality
    public interface IProjectService : IService<ProjectDto, ProjectSummaryDto, FullProjectDto>, IAllService<ProjectSummaryDto>
    {
        IEnumerable<UserProjectSummaryDto> GetAllForUser(string userId);
        PagedDataDto<UserProjectDto> GetAllForUserPaged(string userId, PaginationRequestDto paginationRequest);
        IEnumerable<UserProjectDto> GetFullForUser(string userId);
    }
}