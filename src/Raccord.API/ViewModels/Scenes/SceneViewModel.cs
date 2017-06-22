using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent a scene
    public class SceneViewModel
    {
        private IntExtViewModel _intExt;
        private ScriptLocationViewModel _scriptLocation;
        private DayNightViewModel _dayNight;

        // ID of the scene
        public long ID { get; set; }

        // Number of the scene
        public string Number { get; set; }

        /// Summary of the scene
        public string Summary { get; set; }

        // Page length of the scene
        public int PageLength { get; set; }

        // The linked project ID
        public long ProjectID { get; set; }

        // The Scene's Int/Ext
        public IntExtViewModel IntExt
        {
            get
            {
                return _intExt ?? (_intExt = new IntExtViewModel());
            }
            set
            {
                _intExt = value;
            }
        }

        // The Scene's Location
        public ScriptLocationViewModel ScriptLocation
        {
            get
            {
                return _scriptLocation ?? (_scriptLocation = new ScriptLocationViewModel());
            }
            set
            {
                _scriptLocation = value;
            }
        }

        // The Scene's Day/Night
        public DayNightViewModel DayNight
        {
            get
            {
                return _dayNight ?? (_dayNight = new DayNightViewModel());
            }
            set
            {
                _dayNight = value;
            }
        }
    }
}