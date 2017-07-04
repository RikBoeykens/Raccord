using System.Collections.Generic;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Vm to represent a full schedule day
    public class ScheduleDaySceneCollectionViewModel: ScheduleDayViewModel
    {
        private IEnumerable<ScheduleSceneSceneViewModel> _scenes;

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
    }
}