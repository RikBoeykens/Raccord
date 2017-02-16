namespace Raccord.API.ViewModels.Locations
{
    // ViewModel to represent a summary of a location
    public class LocationSummaryViewModel : LocationViewModel
    {
        // Total count of scenes
        public int SceneCount { get; set; }
    }
}