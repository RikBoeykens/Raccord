using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a summary of a project for a user
    public class UserProjectDto : ProjectSummaryDto
    {
        private IEnumerable<CrewMemberUnitDto> _crewMembers;
        
        /// <summary>
        /// Crew members linked to the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CrewMemberUnitDto> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberUnitDto>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}