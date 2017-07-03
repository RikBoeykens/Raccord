using System;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // Dto to represent a scene on a schedule day
    public class ScheduleSceneViewModel
    {
        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // ID of the linked schedule day
        public long ScheduleDayID { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // ID of the linked location Set
        public long? LocationSetID { get; set; }
    }
}