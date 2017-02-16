namespace Raccord.Application.Core.Services.Projects
{
    // Interface for project functionality
    public interface IProjectService : IService<ProjectSummaryDto, ProjectSummaryDto, ProjectDto>, IAllService<ProjectSummaryDto>
    {
    }
}