using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a summary of a project for a user
    public class UserProjectSummaryDto : ProjectSummaryDto
    {
        public bool HasCast { get; set; }
        public bool HasCrew { get; set; }
    }
}