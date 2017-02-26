namespace Raccord.API.ViewModels.Images
{
    // Viewmodel to represent a image
    public class ImageViewModel
    {
        // ID of the image
        public long ID { get; set; }

        /// Name of the image
        public string Title { get; set; }

        /// Description of the image
        public string Description { get; set; }

        // Name of the file
        public string FileName { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}