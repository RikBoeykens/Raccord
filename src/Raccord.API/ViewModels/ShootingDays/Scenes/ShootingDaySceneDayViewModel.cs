using System;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneDayViewModel : BaseShootingDaySceneViewModel
    {
        private ShootingDayViewModel _shootingDay;
        private LocationSetSummaryViewModel _locationSet;

        // Linked shooting day
        public ShootingDayViewModel ShootingDay
        {
            get
            {
                return _shootingDay ?? (_shootingDay = new ShootingDayViewModel()); 
            }
            set
            {
                _shootingDay = value;
            }
        }

        // Linked location set
        public LocationSetSummaryViewModel LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryViewModel()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}