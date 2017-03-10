using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a full breakdown item
    public class FullBreakdownItemDto: BreakdownItemDto
    {
        private IEnumerable<LinkedSceneDto> _scenes;
        private IEnumerable<LinkedImageDto> _images;

        // Scenes linked to the breakdown item
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

        // Images linked to the breakdown item
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