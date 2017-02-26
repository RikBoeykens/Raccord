using Raccord.Domain.Model.Locations;

namespace Raccord.Domain.Model.Images
{
    // join for image and location
    public class ImageLocation : Entity
    {
        // ID of the linked image
        public long ImageID { get; set; }

        // Linked image
        public virtual Image Image { get; set; }

        // ID of the linked location
        public long LocationID { get; set; }

        // Linked location
        public virtual Location Location { get; set; }
    }
}