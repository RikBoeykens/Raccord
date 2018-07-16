using Raccord.Application.Core.Services.Scenes;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.SceneProperties
{
    // Dto to represent a day/night
    public class FullTimeOfDayDto: TimeOfDayDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;

        // Scenes linked to the day/night
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