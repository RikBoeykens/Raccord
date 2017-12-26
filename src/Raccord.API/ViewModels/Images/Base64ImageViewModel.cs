namespace Raccord.API.ViewModels.Images
{
    // Viewmodel to represent a image
    public class Base64ImageViewModel
    {
        // Content for the image
        public string Content { get; set; }

        // Indicates if there is an image
        public bool HasContent { get; set; }
    }
}