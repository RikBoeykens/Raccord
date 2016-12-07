namespace Raccord.API.ViewModels.Locations
{
    // Viewmodel to represent summary of location
    public class LocationSummaryViewModel
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