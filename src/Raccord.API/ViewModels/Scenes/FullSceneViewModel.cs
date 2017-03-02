using Raccord.API.ViewModels.Images;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent scene
    public class FullSceneViewModel : SceneViewModel
    {
        private IEnumerable<ImageViewModel> _images;

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
    }
}