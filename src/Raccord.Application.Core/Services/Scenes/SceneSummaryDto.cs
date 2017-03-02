using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a summary of a scene
    public class SceneSummaryDto : SceneDto
    {
        private ImageDto _primaryImage;

        // Primary Image for the scene
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