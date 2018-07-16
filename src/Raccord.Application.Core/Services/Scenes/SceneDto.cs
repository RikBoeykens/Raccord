using System;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.ScriptLocations;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a scene
    public class SceneDto
    {
        private SceneIntroDto _sceneIntro;
        private ScriptLocationDto _scriptLocation;
        private TimeOfDayDto _timeOfDay;

        // ID of the scene
        public long ID { get; set; }

        // Number of the scene
        public string Number { get; set; }

        /// Summary of the scene
        public string Summary { get; set; }

        // Page length of the scene
        public int PageLength { get; set; }

        // Timing length of the scene
        public TimeSpan Timing { get; set; }

        // The linked project ID
        public long ProjectID { get; set; }

        // The Scene's Int/Ext
        public SceneIntroDto SceneIntro
        {
            get
            {
                return _sceneIntro ?? (_sceneIntro = new SceneIntroDto());
            }
            set
            {
                _sceneIntro = value;
            }
        }

        // The Scene's Location
        public ScriptLocationDto ScriptLocation
        {
            get
            {
                return _scriptLocation ?? (_scriptLocation = new ScriptLocationDto());
            }
            set
            {
                _scriptLocation = value;
            }
        }

        // The Scene's Day/Night
        public TimeOfDayDto TimeOfDay
        {
            get
            {
                return _timeOfDay ?? new TimeOfDayDto();
            }
            set
            {
                _timeOfDay = value;
            }
        }

    }
}