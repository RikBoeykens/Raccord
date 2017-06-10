using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // Dto to represent a summary of a schedule scene with 
    public class FullScheduleSceneViewModel
    {
        private SceneSummaryViewModel _scene;
        private ScheduleDaySummaryViewModel _scheduleDay;

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
    }
}