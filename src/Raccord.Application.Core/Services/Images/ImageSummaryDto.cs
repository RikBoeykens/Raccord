namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a summary of an image
    public class ImageSummaryDto : ImageDto
    {
        // Indicates if the image is primary image for the project
        public bool IsPrimaryImage { get; set; }
    }
}