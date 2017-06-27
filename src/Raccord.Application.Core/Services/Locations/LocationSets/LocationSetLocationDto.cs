using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a summary of a schedule scene with 
    public class ScheduleSceneDayDto
    {
        private ScheduleDaySummaryDto _scheduleDay;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Linked schedule day
        public ScheduleDaySummaryDto ScheduleDay
        {
            get
            {
                return _scheduleDay ?? (_scheduleDay = new ScheduleDaySummaryDto()); 
            }
            set
            {
                _scheduleDay = value;
            }
        }
    }
}