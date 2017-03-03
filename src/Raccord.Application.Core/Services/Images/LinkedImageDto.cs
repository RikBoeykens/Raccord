namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a image linked to another entity
    public class LinkedImageDto : ImageDto
    {
        // Link ID
        public long LinkID { get; set; }

        // Indicates if the image is primary image for the entity
        public bool IsPrimaryImage { get; set; }
    }
}