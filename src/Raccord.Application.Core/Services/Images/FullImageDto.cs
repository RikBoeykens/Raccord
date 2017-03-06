using Raccord.Application.Core.Services.Scenes;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations;
using Raccord.Application.Core.Services.Characters;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a full image
    public class FullImageDto : ImageDto
    {
        private IEnumerable<LinkedSceneDto> _scenes;
        private IEnumerable<LinkedLocationDto> _locations;
        private IEnumerable<LinkedCharacterDto> _characters;
        
        // Indicates if the image is primary image for the project
        public bool IsPrimaryImage { get; set; }

        // Scenes linked to the image
        public IEnumerable<LinkedSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Locations linked to the image
        public IEnumerable<LinkedLocationDto> Locations
        {
            get
            {
                return _locations ?? (_locations = new List<LinkedLocationDto>());
            }
            set
            {
                _locations = value;
            }
        }

        // Characters linked to the image
        public IEnumerable<LinkedCharacterDto> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterDto>());
            }
            set
            {
                _characters = value;
            }
        }
    }
}