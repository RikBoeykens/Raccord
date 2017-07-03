using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleScenes
{
    // Dto to represent a summary of a schedule scene with 
    public class ScheduleSceneDayDto
    {
        private ScheduleDaySummaryDto _scheduleDay;
        private LocationSetSummaryDto _locationSet;

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

        // Linked location set
        public LocationSetSummaryDto LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryDto()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}