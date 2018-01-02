namespace Raccord.Application.Core.Services.Users
{
    // Dto to represent a user summary
    public class UserSummaryDto : UserDto
    {
        /// <summary>
        /// Indicates if the user has an image
        /// </summary>
        /// <returns></returns>
        public bool HasImage { get; set; }
    }
}