using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a full location
    public class FullLocationDto: LocationDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;
        private IEnumerable<ImageDto> _images;
        private ImageDto _primaryImage;

        // Scenes linked to the location
        public IEnumerable<SceneSummaryDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<SceneSummaryDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Images linked to the location
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

        // Primary Image for the Location
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