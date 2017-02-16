namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a location
    public class LocationDto
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