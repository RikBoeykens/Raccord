namespace Raccord.API.ViewModels.SceneProperties
{
    // Viewmodel to represent summary of day/night
    public class DayNightSummaryViewModel
    {
        // ID of the day/night
        public long ID { get; set; }

        /// Name of the day/night
        public string Name { get; set; }

        /// Description of the day/night
        public string Description { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}