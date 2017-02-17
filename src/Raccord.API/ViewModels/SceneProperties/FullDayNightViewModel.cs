using Raccord.API.ViewModels.Scenes;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.SceneProperties
{
    // ViewModel to represent a full day/night
    public class FullDayNightViewModel : DayNightViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;

        // Scenes linked to the day/night
        public IEnumerable<SceneSummaryViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<SceneSummaryViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}