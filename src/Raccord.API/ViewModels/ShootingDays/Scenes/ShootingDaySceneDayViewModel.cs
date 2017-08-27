using System;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneDayViewModel : BaseShootingDaySceneViewModel
    {
        private ShootingDayViewModel _shootingDay;

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
    }
}