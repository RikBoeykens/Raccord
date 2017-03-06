namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent content for an image
    public class ImageContentDto
    {

        // Content
        public byte[] FileContent { get; set; }

        // File name of the image
        public string FileName { get; set; }
    }
}