using Raccord.Domain.Model.Shots;

namespace Raccord.Domain.Model.Images
{
    // join for image and slate
    public class ImageSlate : Entity<long>
    {
        // Indicates if the image is the primary image for the slate
        public bool IsPrimaryImage { get; set; }

        // ID of the linked image
        public long ImageID { get; set; }

        // Linked image
        public virtual Image Image { get; set; }

        // ID of the linked slate
        public long SlateID { get; set; }

        // Linked slate
        public virtual Slate Slate { get; set; }
    }
}