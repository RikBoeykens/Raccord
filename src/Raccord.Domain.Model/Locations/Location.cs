using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Images;

namespace Raccord.Domain.Model.Locations
{
    /// Represents a location
    public class Location : Entity
    {
        private ICollection<Scene> _scenes;
        private ICollection<ImageLocation> _images;

        /// Name of the location
        public string Name { get; set; }

        /// Description of the location
        public string Description { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // Linked scenes
        public virtual ICollection<Scene> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<Scene>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Linked images
        public virtual ICollection<ImageLocation> ImageLocations
        {
            get
            {
                return _images ?? (_images = new List<ImageLocation>());
            }
            set
            {
                _images = value;
            }
        }
    }
}