using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.ImageCharacters
{
    // Interface for image character functionality
    public interface IImageCharacterService
    {
        IEnumerable<LinkedImageDto> GetImages(long ID);

        // Links an image to a character
        void AddLink(long imageID, long characterID);

        // Removes link between image and character
        void RemoveLink(long ID);

        // Sets the image as primary image for character
        void SetAsPrimary(long ID);

        // Unsets the image as primary image for character
        void RemoveAsPrimary(long ID);
    }
}