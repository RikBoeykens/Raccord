namespace Raccord.Application.Core.Services.Scheduling.ScheduleScenes
{
    // Dto to represent a schedule scene that's linked to something
    public class LinkedScheduleSceneDto: ScheduleSceneSummaryDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}