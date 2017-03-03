namespace Raccord.API.ViewModels.Images
{
    // ViewModel to represent a image linked to an entity
    public class LinkedImageViewModel : ImageViewModel
    {
        // ID of the link
        public long LinkID { get; set; }

        // Indicates if the image is the primary image for the entity
        public bool IsPrimaryImage { get; set; }
    }
}