using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.ScriptLocations
{
    // ViewModel to represent a summary of a location
    public class ScriptLocationSummaryViewModel : ScriptLocationViewModel
    {
        private ImageViewModel _primaryImage;

        // Total count of scenes
        public int SceneCount { get; set; }

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