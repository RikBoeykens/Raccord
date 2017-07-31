using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day summary
    public class ScheduleDaySummaryViewModel: ScheduleDayViewModel
    {
        private ShootingDayViewModel _shootingDay;

        // Full count of scenes
        public int SceneCount {get; set; }

        // Page length in eights
        public int PageLength { get; set; }

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