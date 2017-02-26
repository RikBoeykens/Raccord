using System.IO;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent an image with content
    public class NewImageContentDto
    {
        // File Content
        public Stream FileContent { get; set; }

        // Name of the file
        public string FileName { get; set;}
    }
}