using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Characters
{
    // Dto to represent a full character
    public class CharacterSummaryDto: CharacterDto
    {
        private ImageDto _primaryImage;

        // Full count of scenes
        public int SceneCount {get; set; }

        // Primary Image for the character
        public ImageDto PrimaryImage
        {
            get
            {
                return _primaryImage ?? (_primaryImage = new ImageDto());
            }
            set
            {
                _primaryImage = value;
            }
        }
    }
}