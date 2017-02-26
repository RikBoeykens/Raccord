namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a image
    public class ImageDto
    {
        // ID of the image
        public long ID { get; set; }

        /// Title of the image
        public string Title { get; set; }

        /// Description of the image
        public string Description { get; set; }

        // File name of the image
        public string FileName { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}