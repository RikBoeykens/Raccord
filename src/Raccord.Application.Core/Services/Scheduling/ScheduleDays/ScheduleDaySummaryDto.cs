namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day summary
    public class ScheduleDaySummaryDto: ScheduleDayDto
    {
        // Full count of scenes
        public int SceneCount {get; set; }

        // Page length in eights
        public int PageLength { get; set; }
    }
}