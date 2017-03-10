using Raccord.Domain.Model.Breakdowns.BreakdownItems;

namespace Raccord.Domain.Model.Images
{
    // join for image and BreakdownItem
    public class ImageBreakdownItem : Entity
    {
        // Indicates if the image is the primary image for the BreakdownItem
        public bool IsPrimaryImage { get; set; }

        // ID of the linked image
        public long ImageID { get; set; }

        // Linked image
        public virtual Image Image { get; set; }

        // ID of the linked BreakdownItem
        public long BreakdownItemID { get; set; }

        // Linked BreakdownItem
        public virtual BreakdownItem BreakdownItem { get; set; }
    }
}