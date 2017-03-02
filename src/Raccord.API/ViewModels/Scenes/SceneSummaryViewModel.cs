using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent scene
    public class SceneSummaryViewModel : SceneViewModel
    {
        private ImageViewModel _primaryImage;

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