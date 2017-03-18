using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleScenes
{
    // Dto to represent a summary of a schedule scene with scene info
    public class ScheduleSceneSceneDto
    {
        private SceneSummaryDto _scene;

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
    }
}