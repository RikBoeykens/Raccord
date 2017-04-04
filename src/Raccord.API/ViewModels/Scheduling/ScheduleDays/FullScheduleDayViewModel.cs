using System.Collections.Generic;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Vm to represent a full schedule day
    public class FullScheduleDayViewModel: ScheduleDayViewModel
    {
        private IEnumerable<ScheduleSceneSceneViewModel> _scenes;
        private IEnumerable<ScheduleDayNoteViewModel> _notes;

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

        // Notes added to the day
        public IEnumerable<ScheduleDayNoteViewModel> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<ScheduleDayNoteViewModel>());
            }
            set
            {
                _notes = value;
            }
        }
    }
}