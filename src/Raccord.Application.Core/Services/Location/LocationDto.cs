using Raccord.Application.Core.Services.Scenes;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a location
    public class LocationDto: LocationSummaryDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;

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
    }
}