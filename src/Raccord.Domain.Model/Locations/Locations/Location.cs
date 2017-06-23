using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Locations.Locations
{
    // Represents a physical location
    public class Location : Entity
    {
        // Name of the location
        public string Name { get; set; }

        /// Description of the location
        public string Description { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }
    }
}