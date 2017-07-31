using System.Collections.Generic;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Vm to represent a full schedule day
    public class ScheduleDaySceneCollectionViewModel: ScheduleDayViewModel
    {
        private IEnumerable<ScheduleSceneSceneViewModel> _scenes;
        private ShootingDayViewModel _shootingDay;

        // Scenes scheduled for the day
        public IEnumerable<ScheduleSceneSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ScheduleSceneSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Shooting day associated to the schedule day
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