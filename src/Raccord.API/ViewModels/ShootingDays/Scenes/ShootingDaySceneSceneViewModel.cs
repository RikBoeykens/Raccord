using System;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneSceneViewModel : BaseShootingDaySceneViewModel
    {
        private SceneSummaryViewModel _scene;
        private LocationSetSummaryViewModel _locationSet;

        public int ScenePageLength { get; set; }

        public TimeSpan SceneTimings { get; set; }

        // Previous page length
        public int PreviousPageLength { get; set; }

        // Previous timings
        public TimeSpan PreviousTimings { get; set; }

        // Linked scene
        public SceneSummaryViewModel Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneSummaryViewModel()); 
            }
            set
            {
                _scene = value;
            }
        }

        // Linked location set
        public LocationSetSummaryViewModel LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryViewModel()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}