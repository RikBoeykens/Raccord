namespace Raccord.API.ViewModels.Users
{
    // Viewmodel to represent a user
    public class UserSummaryViewModel : UserViewModel
    {
        /// <summary>
        /// Indicates if the user has an image
        /// </summary>
        /// <returns></returns>
        public bool HasImage { get; set; }
    }
}