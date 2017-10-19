using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Crew.Departments
{
    public class FullCrewDepartmentViewModel : CrewDepartmentViewModel
    {
        private IEnumerable<CrewMemberSummaryViewModel> _crewMembers;

        public IEnumerable<CrewMemberSummaryViewModel> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberSummaryViewModel>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}