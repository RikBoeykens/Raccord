using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a location set for a callsheet
    public class CallsheetLocationSetDto : LocationSetScriptLocationDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;

        // Scenes linked to the location set
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