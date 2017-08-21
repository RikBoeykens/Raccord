using System;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneDayDto : BaseShootingDaySceneDto
    {
        private ShootingDayDto _shootingDay;
        private LocationSetSummaryDto _locationSet;

        // Linked shooting day
        public ShootingDayDto ShootingDay
        {
            get
            {
                return _shootingDay ?? (_shootingDay = new ShootingDayDto()); 
            }
            set
            {
                _shootingDay = value;
            }
        }

        // Linked location set
        public LocationSetSummaryDto LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryDto()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}