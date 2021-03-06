using Raccord.Application.Core.Services.Scenes;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.SceneProperties
{
    // Dto to represent an int/ext
    public class FullSceneIntroDto : SceneIntroDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;

        // Scenes linked to the int/ext
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
    }
}