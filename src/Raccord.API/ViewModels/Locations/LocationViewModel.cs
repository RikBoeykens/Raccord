using Raccord.API.ViewModels.Scenes;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Locations
{
    // ViewModel to represent a location
    public class LocationViewModel : LocationSummaryViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;

        // Scenes linked to the location
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