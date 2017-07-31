using System.Collections.Generic;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day with info specific entity
    public class ScheduleDaySceneCollectionDto: ScheduleDayDto
    {
        private IEnumerable<ScheduleSceneSceneDto> _scenes;
        private ShootingDayDto _shootingDay;

        // Scenes scheduled for the day
        public IEnumerable<ScheduleSceneSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ScheduleSceneSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }

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