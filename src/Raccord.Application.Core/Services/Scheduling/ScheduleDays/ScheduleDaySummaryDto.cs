using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day summary
    public class ScheduleDaySummaryDto: ScheduleDayDto
    {
        private ShootingDayDto _shootingDay;

        // Full count of scenes
        public int SceneCount {get; set; }

        // Page length in eights
        public int PageLength { get; set; }

        // Shooting day linked to schedule day
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
    }
}