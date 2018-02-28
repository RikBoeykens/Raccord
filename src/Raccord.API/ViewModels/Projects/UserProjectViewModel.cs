using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a project summary
    public class UserProjectViewModel : ProjectSummaryViewModel
    {
        private IEnumerable<CrewMemberUnitViewModel> _crewMembers;


        /// <summary>
        /// Crew members linked to the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CrewMemberUnitViewModel> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberUnitViewModel>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}