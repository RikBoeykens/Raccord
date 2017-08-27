using System;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ShootingDaySceneSceneViewModel : BaseShootingDaySceneViewModel
    {
        private SceneSummaryViewModel _scene;

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
    }
}