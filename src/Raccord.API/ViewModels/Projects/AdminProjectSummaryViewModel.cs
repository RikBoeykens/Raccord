using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a project summary
    public class AdminProjectSummaryViewModel : ProjectSummaryViewModel
    {
        public int UserCount { get; set; }

        public int InvitationCount { get; set; }
    }
}