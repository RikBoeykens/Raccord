using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a full scene
    public class FullSceneDto : SceneDto
    {
        private IEnumerable<ImageDto> _images;
        private ImageDto _primaryImage;

        // Images linked to the scene
        public IEnumerable<ImageDto> Images
        {
            get
            {
                return _images ?? (_images = new List<ImageDto>());
            }
            set
            {
                _images = value;
            }
        }

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