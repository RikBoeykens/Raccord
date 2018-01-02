using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a summary of a project for a user
    public class UserProjectDto : ProjectSummaryDto
    {
        private IEnumerable<CrewMemberDto> _crewMembers;
        
        /// <summary>
        /// Crew members linked to the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CrewMemberDto> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberDto>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}