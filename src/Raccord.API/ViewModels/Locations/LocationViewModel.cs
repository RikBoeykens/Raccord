namespace Raccord.API.ViewModels.Locations
{
    // Viewmodel to represents a location
    public class LocationViewModel
    {
        // ID of the location
        public long ID { get; set; }

        /// Name of the location
        public string Name { get; set; }

        /// Description of the location
        public string Description { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}