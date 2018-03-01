using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.Application.Core.Services.Crew.CrewMembers
{
    public class CrewMemberUnitDto : CrewMemberDto
    {
        private CrewUnitDto _crewUnit;

        public CrewUnitDto CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitDto();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}