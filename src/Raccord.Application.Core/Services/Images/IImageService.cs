using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Images
{
    // Interface for image functionality
    public interface IImageService
    {
        // Returns a single full instance
        FullImageDto Get(long ID);

        // Returns the summary of a single instance
        ImageSummaryDto GetSummary(long ID);

        // Returns all as summary
        IEnumerable<ImageSummaryDto> GetAllForProject(long projectID);

        // Adds a single instance
        IEnumerable<long> Add(AddImageContentDto dto);
        
        // Updates a single instance
        long Update(ImageDto dto);

        // Deletes a single instance
        void Delete(long ID);

        // Gets content of an image
        ImageContentDto GetContent(long ID);

        // Sets the image as primary image for project
        void SetAsPrimary(long ID);

        // Unsets the image as primary image for project
        void RemoveAsPrimary(long ID);
    }
}