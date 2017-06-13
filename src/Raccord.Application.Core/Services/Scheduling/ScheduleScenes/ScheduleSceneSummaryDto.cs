using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleScenes
{
    // Dto to represent a scene on a schedule day
    public class ScheduleSceneSummaryDto
    {
        private SceneSummaryDto _scene;
        private ScheduleDaySummaryDto _scheduleDay;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Linked scene
        public SceneSummaryDto Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneSummaryDto()); 
            }
            set
            {
                _scene = value;
            }
        }

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