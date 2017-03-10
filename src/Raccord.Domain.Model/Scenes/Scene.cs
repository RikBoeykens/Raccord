using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Locations;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;

namespace Raccord.Domain.Model.Scenes
{
    /// Represents a scene
    public class Scene : Entity
    {
        private ICollection<ImageScene> _images;
        private ICollection<CharacterScene> _characters;
        private ICollection<BreakdownItemScene> _breakdownItems;

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

        // Linked characters
        public virtual ICollection<CharacterScene> CharacterScenes
        {
            get
            {
                return _characters ?? (_characters = new List<CharacterScene>());
            }
            set
            {
                _characters = value;
            }
        }

        // Linked breakdown items
        public virtual ICollection<BreakdownItemScene> BreakdownItemScenes
        {
            get
            {
                return _breakdownItems ?? (_breakdownItems = new List<BreakdownItemScene>());
            }
            set
            {
                _breakdownItems = value;
            }
        }
    }
}