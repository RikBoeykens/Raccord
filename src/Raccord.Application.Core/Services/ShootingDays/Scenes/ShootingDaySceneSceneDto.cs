using System;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneSceneDto : BaseShootingDaySceneDto
    {
        private SceneSummaryDto _scene;
        private LocationSetSummaryDto _locationSet;

        public int ScenePageLength { get; set; }

        public TimeSpan SceneTimings { get; set; }

        // Previous page length
        public int PreviousPageLength { get; set; }

        // Previous timings
        public TimeSpan PreviousTimings { get; set; }

        // Linked scene
        public SceneSummaryDto Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneSummaryDto()); 
            }
            set
            {
                _scene = value;
            }
        }

        // Linked location set
        public LocationSetSummaryDto LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryDto()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}