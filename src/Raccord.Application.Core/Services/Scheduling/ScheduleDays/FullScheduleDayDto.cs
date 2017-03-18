using System.Collections.Generic;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a full schedule day
    public class FullScheduleDayDto: ScheduleDayDto
    {
        private IEnumerable<ScheduleSceneSceneDto> _scenes;
        private IEnumerable<ScheduleDayNoteDto> _notes;

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

        // Notes added to the day
        public IEnumerable<ScheduleDayNoteDto> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<ScheduleDayNoteDto>());
            }
            set
            {
                _notes = value;
            }
        }
    }
}