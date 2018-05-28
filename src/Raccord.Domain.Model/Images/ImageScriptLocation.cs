using Raccord.Domain.Model.ScriptLocations;

namespace Raccord.Domain.Model.Images
{
    // join for image and script location
    public class ImageScriptLocation : Entity<long>
    {
        // Indicates if the image is the primary image for the location
        public bool IsPrimaryImage { get; set; }

        // ID of the linked image
        public long ImageID { get; set; }

        // Linked image
        public virtual Image Image { get; set; }

        // ID of the linked location
        public long ScriptLocationID { get; set; }

        // Linked script location
        public virtual ScriptLocation ScriptLocation { get; set; }
    }
}