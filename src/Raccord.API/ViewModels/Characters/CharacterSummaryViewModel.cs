using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Characters
{
    // ViewModel to represent a summary of a character
    public class CharacterSummaryViewModel : CharacterViewModel
    {
        private ImageViewModel _primaryImage;

        // Total count of scenes
        public int SceneCount { get; set; }

        // Primary image linked to the character
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