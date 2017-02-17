using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Locations;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent a scene
    public class SceneViewModel
    {
        private IntExtSummaryViewModel _intExt;
        private LocationViewModel _location;
        private DayNightSummaryViewModel _dayNight;

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
        public IntExtSummaryViewModel IntExt
        {
            get
            {
                return _intExt ?? (_intExt = new IntExtSummaryViewModel());
            }
            set
            {
                _intExt = value;
            }
        }

        // The Scene's Location
        public LocationViewModel Location
        {
            get
            {
                return _location ?? (_location = new LocationViewModel());
            }
            set
            {
                _location = value;
            }
        }

        // The Scene's Day/Night
        public DayNightSummaryViewModel DayNight
        {
            get
            {
                return _dayNight ?? (_dayNight = new DayNightSummaryViewModel());
            }
            set
            {
                _dayNight = value;
            }
        }
    }
}