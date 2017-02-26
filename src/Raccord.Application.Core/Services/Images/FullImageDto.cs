using Raccord.Application.Core.Services.Scenes;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a full image
    public class FullImageDto : ImageDto
    {
        private IEnumerable<SceneDto> _scenes;
        private IEnumerable<LocationDto> _locations;

        // Scenes linked to the image
        public IEnumerable<SceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<SceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Scenes linked to the image
        public IEnumerable<LocationDto> Locations
        {
            get
            {
                return _locations ?? (_locations = new List<LocationDto>());
            }
            set
            {
                _locations = value;
            }
        }
    }
}