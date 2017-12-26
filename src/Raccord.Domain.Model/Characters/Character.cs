using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.ScriptUploads;
using Raccord.Domain.Model.Scenes.Dialogues;

namespace Raccord.Domain.Model.Characters
{
    /// Represents a character
    public class Character : Entity
    {
        private ICollection<CharacterScene> _scenes;
        private ICollection<ImageCharacter> _images;
        private ICollection<SceneDialogue> _dialogues;

        // Number for the character
        public int Number { get; set; }

        /// Name of the character
        public string Name { get; set; }

        /// Description of the character
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
        public virtual ICollection<CharacterScene> CharacterScenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<CharacterScene>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Linked images
        public virtual ICollection<ImageCharacter> ImageCharacters
        {
            get
            {
                return _images ?? (_images = new List<ImageCharacter>());
            }
            set
            {
                _images = value;
            }
        }

        // Linked scene dialogues
        public virtual ICollection<SceneDialogue> Dialogues
        {
            get
            {
                return _dialogues ?? (_dialogues = new List<SceneDialogue>());
            }
            set
            {
                _dialogues = value;
            }
        }
    }
}