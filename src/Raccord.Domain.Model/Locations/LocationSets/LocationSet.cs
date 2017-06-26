using Raccord.Domain.Model.Locations.Locations;
using Raccord.Domain.Model.ScriptLocations;

namespace Raccord.Domain.Model.Locations.LocationSets
{
    // Represents a set on a location, linked to a script location
    public class LocationSet : Entity
    {
        /// Name of the set
        public string Name { get; set; }

        /// Description of the set
        public string Description { get; set; }

        // Latitute of the set
        public double? Latitude { get; set; }

        // Longitude of the set
        public double? Longitude { get; set; }

        // ID of the linked location
        public long LocationID { get; set; }

        // Linked location
        public virtual Location Location { get; set; }

        // ID of the linked script location
        public long ScriptLocationID { get; set; }

        // Linked script location
        public virtual ScriptLocation ScriptLocation { get; set; }
    }
}