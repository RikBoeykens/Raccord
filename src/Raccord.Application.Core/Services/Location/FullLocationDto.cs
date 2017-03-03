using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a full location
    public class FullLocationDto: LocationDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;
        private IEnumerable<LinkedImageDto> _images;

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
        public IEnumerable<LinkedImageDto> Images
        {
            get
            {
                return _images ?? (_images = new List<LinkedImageDto>());
            }
            set
            {
                _images = value;
            }
        }
    }
}