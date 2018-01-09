namespace Raccord.API.ViewModels.Account
{
    public class UserSummaryViewModel
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        // Email of the user
        public string Email { get; set; }

        // Gets or sets if user is admin
        public bool IsAdmin { get; set; }

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