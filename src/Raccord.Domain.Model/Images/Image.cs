using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Locations;

namespace Raccord.Domain.Model.Images
{
    /// Represents a image
    public class Image : Entity
    {
        private ICollection<ImageScene> _scenes;
        private ICollection<ImageLocation> _locations;
        private ICollection<ImageCharacter> _characters;

        /// Title of the image
        public string Title { get; set; }

        /// Description of the image
        public string Description { get; set; }

        // File content of the image
        public byte[] FileContent { get; set; }

        // File name of the image
        public string FileName { get; set; }

        // Indicates if the image is the primary image for the project
        public bool IsPrimaryImage { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // Linked scenes
        public virtual ICollection<ImageScene> ImageScenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ImageScene>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Linked locations
        public virtual ICollection<ImageLocation> ImageLocations
        {
            get
            {
                return _locations ?? (_locations = new List<ImageLocation>());
            }
            set
            {
                _locations = value;
            }
        }

        // Linked characters
        public virtual ICollection<ImageCharacter> ImageCharacters
        {
            get
            {
                return _characters ?? (_characters = new List<ImageCharacter>());
            }
            set
            {
                _characters = value;
            }
        }
    }
}