using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Locations;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.Images;

namespace Raccord.Domain.Model.Scenes
{
    /// Represents a scene
    public class Scene : Entity
    {
        private ICollection<ImageScene> _images;

        // Number of the scene
        public string Number { get; set; }

        // Summary of the scene
        public string Summary { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // The sorting order of the scene within the project
        public int SortingOrder { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked int/ext
        public long IntExtID { get; set; }

        // Linked int/ext
        public virtual IntExt IntExt { get; set; }

        // ID of the linked day/night
        public long DayNightID { get; set; }

        // Linked day/night
        public virtual DayNight DayNight { get; set; }

        // ID of the linked day/night
        public long LocationID { get; set; }

        // Linked day/night
        public virtual Location Location { get; set; }

        // Linked images
        public virtual ICollection<ImageScene> ImageScenes
        {
            get
            {
                return _images ?? (_images = new List<ImageScene>());
            }
            set
            {
                _images = value;
            }
        }
    }
}