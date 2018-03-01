using System;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDayCrewUnitViewModel : BaseShootingDayViewModel
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