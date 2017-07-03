using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // Dto to represent a summary of a schedule scene with 
    public class FullScheduleSceneViewModel
    {
        private SceneSummaryViewModel _scene;
        private ScheduleDaySummaryViewModel _scheduleDay;
        private IEnumerable<LinkedCharacterViewModel> _characters;
        private LocationSetSummaryViewModel _locationSet;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Length in eights
        public int SceneScheduledPageLength { get; set; }

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

        // Linked characters
        public IEnumerable<LinkedCharacterViewModel> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterViewModel>()); 
            }
            set
            {
                _characters = value;
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