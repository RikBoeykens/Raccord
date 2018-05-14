using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a project summary
    public class UserProjectSummaryViewModel : ProjectSummaryViewModel
    {
        public bool HasCrew { get; set; }
        public bool HasCast { get; set; }
    }
}