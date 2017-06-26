using System.Collections.Generic;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Locations.Locations
{
    // Represents a physical location
    public class Location : Entity
    {
        private ICollection<LocationSet> _sets;
        
        // Name of the location
        public string Name { get; set; }

        /// Description of the location
        public string Description { get; set; }

        // First line of the address
        public string Address1 { get; set; }

        // Second line of the address
        public string Address2 { get; set; }

        // Third line of the address
        public string Address3 { get; set; }

        // Fourth line of the address
        public string Address4 { get; set; }

        // Latitute of the location
        public double? Latitude { get; set; }

        // Longitude of the location
        public double? Longitude { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // Linked sets
        public virtual ICollection<LocationSet> LocationSets
        {
            get
            {
                return _sets ?? (_sets = new List<LocationSet>());
            }
            set
            {
                _sets = value;
            }
        }
    }
}