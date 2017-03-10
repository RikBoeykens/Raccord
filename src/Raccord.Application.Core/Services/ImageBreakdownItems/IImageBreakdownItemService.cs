using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.ImageBreakdownItems
{
    // Interface for image breakdown item functionality
    public interface IImageBreakdownItemService
    {
        IEnumerable<LinkedImageDto> GetImages(long ID);

        // Links an image to a breakdown item
        void AddLink(long imageID, long breakdownItemID);

        // Removes link between image and breakdown item
        void RemoveLink(long ID);

        // Sets the image as primary image for breakdown item
        void SetAsPrimary(long ID);

        // Unsets the image as primary image for breakdown item
        void RemoveAsPrimary(long ID);
    }
}