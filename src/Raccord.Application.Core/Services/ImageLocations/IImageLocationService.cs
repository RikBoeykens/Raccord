using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.ImageLocations
{
    // Interface for location functionality
    public interface IImageLocationService
    {
        IEnumerable<LinkedImageDto> GetImages(long ID);

        // Links an image to a location
        void AddLink(long imageID, long locationID);

        // Removes link between image and location
        void RemoveLink(long ID);

        // Sets the image as primary image for location
        void SetAsPrimary(long ID);

        // Unsets the image as primary image for location
        void RemoveAsPrimary(long ID);
    }
}