using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a project summary
    public class UserProjectViewModel : ProjectSummaryViewModel
    {
        private IEnumerable<CrewMemberViewModel> _crewMembers;


        /// <summary>
        /// Crew members linked to the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CrewMemberViewModel> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberViewModel>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}