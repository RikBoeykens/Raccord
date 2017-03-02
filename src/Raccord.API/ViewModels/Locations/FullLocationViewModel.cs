using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Locations
{
    // ViewModel to represent a location
    public class FullLocationViewModel : LocationViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;
        private IEnumerable<ImageViewModel> _images;
        private ImageViewModel _primaryImage;

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
        public IEnumerable<ImageViewModel> Images
        {
            get
            {
                return _images ?? (_images = new List<ImageViewModel>());
            }
            set
            {
                _images = value;
            }
        }

        // Primary image linked to the location
        public ImageViewModel PrimaryImage
        {
            get
            {
                return _primaryImage ?? (_primaryImage = new ImageViewModel());
            }
            set
            {
                _primaryImage = value;
            }
        }
    }
}