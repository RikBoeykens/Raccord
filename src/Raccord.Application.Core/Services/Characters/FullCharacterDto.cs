using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Characters
{
    // Dto to represent a full character
    public class FullCharacterDto: CharacterDto
    {
        private IEnumerable<LinkedSceneDto> _scenes;
        private IEnumerable<LinkedImageDto> _images;

        // Scenes linked to the character
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

        // Images linked to the character
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