namespace Raccord.Application.Core.Services.Projects
{
    // Interface for project functionality
    public interface IProjectService : IService<ProjectDto, ProjectSummaryDto, FullProjectDto>, IAllService<ProjectSummaryDto>
    {
    }
}