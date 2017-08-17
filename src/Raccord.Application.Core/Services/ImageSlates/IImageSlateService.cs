using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.ImageSlates
{
    // Interface for image slate functionality
    public interface IImageSlateService
    {
        IEnumerable<LinkedImageDto> GetImages(long ID);

        // Links an image to a slate
        void AddLink(long imageID, long slateID);

        // Removes link between image and slate
        void RemoveLink(long ID);

        // Sets the image as primary image for slate
        void SetAsPrimary(long ID);

        // Unsets the image as primary image for slate
        void RemoveAsPrimary(long ID);
    }
}