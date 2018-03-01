using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Callsheets
{
    // Dto to represent a callsheet crew unit
    public class CallsheetCrewUnitViewModel: BaseCallsheetViewModel
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