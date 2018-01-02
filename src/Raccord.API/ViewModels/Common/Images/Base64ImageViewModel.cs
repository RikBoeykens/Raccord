namespace Raccord.API.ViewModels.Common.Images
{
    // Viewmodel to represent a image
    public class Base64ImageViewModel
    {
        /// <summary>
        /// Name of the file
        /// </summary>
        /// <returns></returns>
        public string FileName { get; set; }

        // Content for the image
        public string Content { get; set; }

        // Indicates if there is an image
        public bool HasContent { get; set; }
    }
}