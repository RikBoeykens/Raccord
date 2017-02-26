using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Locations;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Images
{
    // ViewModel to represent a image
    public class FullImageViewModel : ImageViewModel
    {
        private IEnumerable<SceneViewModel> _scenes;
        private IEnumerable<LocationViewModel> _locations;

        // Scenes linked to the image
        public IEnumerable<SceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<SceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Locations linked to the image
        public IEnumerable<LocationViewModel> Locations
        {
            get
            {
                return _locations ?? (_locations = new List<LocationViewModel>());
            }
            set
            {
                _locations = value;
            }
        }
    }
}