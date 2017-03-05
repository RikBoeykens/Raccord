using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.ImageScenes
{
    // Interface for scene functionality
    public interface IImageSceneService
    {
        IEnumerable<LinkedImageDto> GetImages(long ID);

        // Links an image to a scene
        void AddLink(long imageID, long sceneID);

        // Removes link between image and scene
        void RemoveLink(long ID);

        // Sets the image as primary image for scene
        void SetAsPrimary(long ID);

        // Unsets the image as primary image for scene
        void RemoveAsPrimary(long ID);
    }
}