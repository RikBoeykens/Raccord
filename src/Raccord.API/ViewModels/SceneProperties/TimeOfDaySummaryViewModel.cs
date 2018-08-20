namespace Raccord.API.ViewModels.SceneProperties
{
    // Viewmodel to represent a day/night
    public class TimeOfDaySummaryViewModel : TimeOfDayViewModel
    {
        // Number of scenes with this day/night
        public int SceneCount {get; set;}
    }
}