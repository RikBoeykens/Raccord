using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Projects
{
    // Interface for project functionality
    public interface IProjectService : IService<ProjectDto, ProjectSummaryDto, FullProjectDto>, IAllService<ProjectSummaryDto>
    {
        IEnumerable<UserProjectSummaryDto> GetAllForUser(string userId);
        IEnumerable<UserProjectDto> GetFullForUser(string userId);
    }
}