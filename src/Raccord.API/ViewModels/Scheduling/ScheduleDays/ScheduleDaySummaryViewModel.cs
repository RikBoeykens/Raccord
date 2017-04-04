namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Dto to represent a schedule day summary
    public class ScheduleDaySummaryViewModel: ScheduleDayViewModel
    {
        // Full count of scenes
        public int SceneCount {get; set; }

        // Page length in eights
        public int PageLength { get; set; }
    }
}