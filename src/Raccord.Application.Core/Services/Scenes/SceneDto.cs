using System;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.ScriptLocations;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a scene
    public class SceneDto
    {
        private IntExtDto _intExt;
        private ScriptLocationDto _scriptLocation;
        private DayNightDto _dayNight;

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
        public IntExtDto IntExt
        {
            get
            {
                return _intExt ?? (_intExt = new IntExtDto());
            }
            set
            {
                _intExt = value;
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
        public DayNightDto DayNight
        {
            get
            {
                return _dayNight ?? (_dayNight = new DayNightDto());
            }
            set
            {
                _dayNight = value;
            }
        }

    }
}