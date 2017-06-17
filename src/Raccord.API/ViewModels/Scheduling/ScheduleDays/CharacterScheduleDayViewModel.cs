using System.Collections.Generic;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Vm to represent a full schedule day
    public class CharacterScheduleDayViewModel: ScheduleDayViewModel
    {
        private IEnumerable<LinkedSceneViewModel> _scenes;

        // Scenes scheduled for the day
        public IEnumerable<LinkedSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}