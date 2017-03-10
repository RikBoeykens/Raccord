using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a full scene
    public class FullSceneDto : SceneDto
    {
        private IEnumerable<LinkedImageDto> _images;
        private IEnumerable<LinkedCharacterDto> _characters;
        private IEnumerable<LinkedBreakdownItemDto> _items;

        // Images linked to the scene
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

        // Characters linked to the scene
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

        // Breakdown items linked to the scene
        public IEnumerable<LinkedBreakdownItemDto> BreakdownItems
        {
            get
            {
                return _items ?? (_items = new List<LinkedBreakdownItemDto>());
            }
            set
            {
                _items = value;
            }
        }
    }
}