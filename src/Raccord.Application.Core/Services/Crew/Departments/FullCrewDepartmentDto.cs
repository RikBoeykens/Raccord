using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.Application.Core.Services.Crew.Departments
{
    public class FullCrewDepartmentDto : CrewDepartmentDto
    {
        private IEnumerable<CrewMemberSummaryDto> _crewMembers;

        public IEnumerable<CrewMemberSummaryDto> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberSummaryDto>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}