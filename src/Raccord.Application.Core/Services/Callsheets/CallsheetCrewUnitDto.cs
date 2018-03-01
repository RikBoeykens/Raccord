using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a callsheet with crew unit info
    public class CallsheetCrewUnitDto: BaseCallsheetDto
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