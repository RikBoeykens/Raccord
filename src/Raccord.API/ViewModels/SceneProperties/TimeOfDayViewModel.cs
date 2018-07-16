namespace Raccord.API.ViewModels.SceneProperties
{
    // Viewmodel to represent a day/night
    public class TimeOfDayViewModel
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