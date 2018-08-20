namespace Raccord.Application.Core.Services.SceneProperties
{
    // Dto to represent summary of a day/night
    public class TimeOfDaySummaryDto: TimeOfDayDto
    {
        public int SceneCount { get; set; }
    }
}