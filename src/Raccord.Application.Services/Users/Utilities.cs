using Raccord.Application.Core.Services.Users;
using Raccord.Domain.Model.Users;

namespace Raccord.Application.Services.Users
{
    public static class Utilities
    {
        public static FullUserDto TranslateFull(this ApplicationUser user)
        {
            return new FullUserDto
            {
                ID = user.Id,
                Email = user.Email,
            };
        }

        public static UserSummaryDto TranslateSummary(this ApplicationUser user)
        {
            return new UserSummaryDto
            {
                ID = user.Id,
                Email = user.Email,
            };
        }

        public static UserDto Translate(this ApplicationUser user)
        {
            return new UserDto
            {
                ID = user.Id,
                Email = user.Email,
            };
        }
    }
}