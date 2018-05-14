using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a project summary
    public class UserProjectViewModel : ProjectSummaryViewModel
    {
        private IEnumerable<CrewMemberUnitViewModel> _crewMembers;
        private IEnumerable<CharacterViewModel> _characters;


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
        /// <summary>
        /// Crew members linked to the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CharacterViewModel> Characters
        {
            get
            {
                return _characters ?? new List<CharacterViewModel>();
            }
            set
            {
                _characters = value;
            }
        }
    }
}