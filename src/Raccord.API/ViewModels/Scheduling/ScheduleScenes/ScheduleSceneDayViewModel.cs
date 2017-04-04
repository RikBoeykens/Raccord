using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ScheduleSceneDayViewModel
    {
        private ScheduleDaySummaryViewModel _scheduleDay;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

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