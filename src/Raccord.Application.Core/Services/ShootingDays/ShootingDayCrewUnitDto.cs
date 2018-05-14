using System;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDayCrewUnitDto : BaseShootingDayDto
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