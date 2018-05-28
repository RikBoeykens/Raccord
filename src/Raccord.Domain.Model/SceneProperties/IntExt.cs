using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.ScriptUploads;

namespace Raccord.Domain.Model.SceneProperties
{
    /// Represents int/ext options
    public class IntExt : Entity<long>
    {
        private ICollection<Scene> _scenes;

        /// Name of the int/ext
        public string Name { get; set; }

        /// Description of the int/ext
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
    }
}