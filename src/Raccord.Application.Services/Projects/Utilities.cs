using Raccord.Application.Core.Services.Projects;
using Raccord.Domain.Model.Projects;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Projects
{
    // Utilities and helper methods for Projects
    public static class Utilities
    {
        public static FullProjectDto TranslateFull(this Project project)
        {
            var dto = new FullProjectDto
            {
                ID = project.ID,
                Title = project.Title,
            };

            return dto;
        }
        public static ProjectSummaryDto TranslateSummary(this Project project)
        {
            var dto = new ProjectSummaryDto
            {
                ID = project.ID,
                Title = project.Title,
            };

            return dto;
        }
        public static ProjectDto Translate(this Project project)
        {
            var dto = new ProjectDto
            {
                ID = project.ID,
                Title = project.Title,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Project project)
        {
            var dto = new SearchResultDto
            {
                RouteIDs = new long[]{project.ID},
                DisplayName = project.Title,
                Type = EntityType.Project,
            };

            return dto;
        }
    }
}