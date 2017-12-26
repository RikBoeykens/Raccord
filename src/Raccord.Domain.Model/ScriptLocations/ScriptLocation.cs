using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Domain.Model.ScriptUploads;

namespace Raccord.Domain.Model.ScriptLocations
{
    /// Represents a location
    public class ScriptLocation : Entity
    {
        private ICollection<Scene> _scenes;
        private ICollection<ImageScriptLocation> _images;
        private ICollection<LocationSet> _sets;

        /// Name of the location
        public string Name { get; set; }

        /// Description of the location
        public string Description { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked script upload
        public long? ScriptUploadID { get; set; }

        // Linked script upload
        public virtual ScriptUpload ScriptUpload { get; set; }

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
        public virtual ICollection<ImageScriptLocation> ImageLocations
        {
            get
            {
                return _images ?? (_images = new List<ImageScriptLocation>());
            }
            set
            {
                _images = value;
            }
        }

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