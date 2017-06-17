namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // ViewModel to represent a schedule scene that's linked to something
    public class LinkedScheduleSceneViewModel: ScheduleSceneSummaryViewModel
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}