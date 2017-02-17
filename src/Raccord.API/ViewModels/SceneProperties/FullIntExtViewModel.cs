using Raccord.API.ViewModels.Scenes;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.SceneProperties
{
    // ViewModel to represent a int/ext
    public class FullIntExtViewModel : IntExtViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;

        // Scenes linked to the int/ext
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