using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Locations
{
    // ViewModel to represent a location
    public class FullLocationViewModel : LocationViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;
        private IEnumerable<LinkedImageViewModel> _images;

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

        // Images linked to the location
        public IEnumerable<LinkedImageViewModel> Images
        {
            get
            {
                return _images ?? (_images = new List<LinkedImageViewModel>());
            }
            set
            {
                _images = value;
            }
        }
    }
}