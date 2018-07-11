namespace Raccord.Application.Core.Services.Users
{
    // Dto to represent a user summary
    public class AdminUserSummaryDto : UserSummaryDto
    {
        public int ProjectCount { get; set; }
    }
}