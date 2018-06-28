using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a summary of a project
    public class AdminProjectSummaryDto : ProjectSummaryDto
    {
        public int UserCount { get; set; }

        public int InvitationCount { get; set; }
    }
}