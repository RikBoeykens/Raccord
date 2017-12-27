using System.Collections.Generic;
using Raccord.API.ViewModels.Scenes;

namespace Raccord.API.ViewModels.Locations.LocationSets
{
    // Dto to represent a location set for a callsheet
    public class CallsheetLocationSetViewModel : LocationSetScriptLocationViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;

        // Scenes linked to the location set
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