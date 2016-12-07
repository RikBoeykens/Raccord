using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.SceneProperties
{
    /// Represents day/night options
    public class DayNight : Entity
    {
        private ICollection<Scene> _scenes;

        /// Name of the day/night
        public string Name { get; set; }

        /// Description of the day/night
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
    }
}