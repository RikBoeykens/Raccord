namespace Raccord.Application.Core.Services.Scheduling.ScheduleScenes
{
    // Dto to represent a scene on a schedule day
    public class ScheduleSceneDto
    {
        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // ID of the linked schedule day
        public long ScheduleDayID { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }
    }
}