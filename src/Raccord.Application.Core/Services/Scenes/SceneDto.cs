using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Locations;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a scene
    public class SceneDto
    {
        private IntExtSummaryDto _intExt;
        private LocationDto _location;
        private DayNightDto _dayNight;

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
        public IntExtSummaryDto IntExt
        {
            get
            {
                return _intExt ?? (_intExt = new IntExtSummaryDto());
            }
            set
            {
                _intExt = value;
            }
        }

        // The Scene's Location
        public LocationDto Location
        {
            get
            {
                return _location ?? (_location = new LocationDto());
            }
            set
            {
                _location = value;
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