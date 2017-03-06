using Raccord.Domain.Model.Characters;

namespace Raccord.Domain.Model.Images
{
    // join for image and character
    public class ImageCharacter : Entity
    {
        // Indicates if the image is the primary image for the character
        public bool IsPrimaryImage { get; set; }

        // ID of the linked image
        public long ImageID { get; set; }

        // Linked image
        public virtual Image Image { get; set; }

        // ID of the linked scene
        public long CharacterID { get; set; }

        // Linked character
        public virtual Character Character { get; set; }
    }
}