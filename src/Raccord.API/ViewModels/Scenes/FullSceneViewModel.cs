using Raccord.API.ViewModels.Images;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent scene
    public class FullSceneViewModel : SceneViewModel
    {
        private IEnumerable<ImageViewModel> _images;
        private ImageViewModel _primaryImage;

        // Images linked to the scene
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

        // Primary image linked to the scene
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