using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneSceneViewModel : BaseShootingDaySceneViewModel
    {
        private SceneSummaryViewModel _scene;
        private LocationSetLocationViewModel _locationSet;
        private IEnumerable<LocationSetLocationViewModel> _availableLocationSets;

        public int ScenePageLength { get; set; }

        public TimeSpan SceneTimings { get; set; }

        // Previous page length
        public int PreviousPageLength { get; set; }

        // Previous timings
        public TimeSpan PreviousTimings { get; set; }

        // Planned page length
        public int PlannedPageLength { get; set; }

        // Indicates if the scene has been completed elsewhere
        public bool CompletedByOther { get; set; }

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
        public LocationSetLocationViewModel LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetLocationViewModel()); 
            }
            set
            {
                _locationSet = value;
            }
        }

        // Linked location set
        public IEnumerable<LocationSetLocationViewModel> AvailableLocationSets
        {
            get
            {
                return _availableLocationSets ?? (_availableLocationSets = new List<LocationSetLocationViewModel>()); 
            }
            set
            {
                _availableLocationSets = value;
            }
        }
    }
}