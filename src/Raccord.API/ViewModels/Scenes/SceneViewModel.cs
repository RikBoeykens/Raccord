using System;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent a scene
    public class SceneViewModel
    {
        private SceneIntroViewModel _sceneIntro;
        private ScriptLocationViewModel _scriptLocation;
        private TimeOfDayViewModel _timeOfDay;

        // ID of the scene
        public long ID { get; set; }

        // Number of the scene
        public string Number { get; set; }

        /// Summary of the scene
        public string Summary { get; set; }

        // Page length of the scene
        public int PageLength { get; set; }

        // Timing of the scene
        public TimeSpan Timing { get; set; }

        // The linked project ID
        public long ProjectID { get; set; }

        // The Scene's Int/Ext
        public SceneIntroViewModel SceneIntro
        {
            get
            {
                return _sceneIntro ?? new SceneIntroViewModel();
            }
            set
            {
                _sceneIntro = value;
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
        public TimeOfDayViewModel TimeOfDay
        {
            get
            {
                return _timeOfDay ?? new TimeOfDayViewModel();
            }
            set
            {
                _timeOfDay = value;
            }
        }
    }
}