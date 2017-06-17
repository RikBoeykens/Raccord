using System.Collections.Generic;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day with info specific to a character
    public class CharacterScheduleDayDto: ScheduleDayDto
    {
        private IEnumerable<LinkedSceneDto> _scenes;

        // Scenes scheduled for the day
        public IEnumerable<LinkedSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}