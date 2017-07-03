using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // Viewmodel to represent a scene on a schedule day
    public class ScheduleSceneSummaryViewModel
    {
        private SceneSummaryViewModel _scene;
        private ScheduleDaySummaryViewModel _scheduleDay;
        private LocationSetSummaryViewModel _locationSet;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

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

        // Linked schedule day
        public ScheduleDaySummaryViewModel ScheduleDay
        {
            get
            {
                return _scheduleDay ?? (_scheduleDay = new ScheduleDaySummaryViewModel()); 
            }
            set
            {
                _scheduleDay = value;
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