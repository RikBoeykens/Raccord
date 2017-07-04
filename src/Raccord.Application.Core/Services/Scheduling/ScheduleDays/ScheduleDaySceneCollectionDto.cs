using System.Collections.Generic;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day with info specific entity
    public class ScheduleDaySceneCollectionDto: ScheduleDayDto
    {
        private IEnumerable<ScheduleSceneSceneDto> _scenes;

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
    }
}