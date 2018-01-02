namespace Raccord.API.ViewModels.Users
{
    // Viewmodel to represent a user
    public class UserViewModel
    {
        // ID of the user
        public string ID { get; set; }

        // Email of the user
        public string Email { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        /// <returns></returns>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        /// <returns></returns>
        public string LastName { get; set; }
    }
}