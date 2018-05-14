using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Crew.CrewMembers
{
    public class CrewMemberUnitViewModel : CrewMemberViewModel
    {
        private CrewUnitViewModel _crewUnit;

        public CrewUnitViewModel CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitViewModel();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}