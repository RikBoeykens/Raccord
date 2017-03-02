namespace Raccord.API.ViewModels.Images
{
    // ViewModel to represent a summary of a image
    public class ImageSummaryViewModel : ImageViewModel
    {
        // Indicates if the image is primary image for the project
        public bool IsPrimaryImage { get; set; }
    }
}