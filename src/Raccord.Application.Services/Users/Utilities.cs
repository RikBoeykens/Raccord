using Raccord.Application.Core.Common.Routing;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Users;
using Raccord.Core.Enums;
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
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public static UserSummaryDto TranslateSummary(this ApplicationUser user)
        {
            return new UserSummaryDto
            {
                ID = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                HasImage = user.ImageContent != null
            };
        }

        public static UserDto Translate(this ApplicationUser user)
        {
            return new UserDto
            {
                ID = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public static SearchResultDto TranslateToSearchResult(this ApplicationUser user)
        {
            var dto = new SearchResultDto
            {
                ID = user.Id,
                DisplayName = $"{user.FirstName} {user.LastName}",
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new string[]{user.Id},
                    Type = EntityType.User,
                }
            };
            return dto;
        }
    }
}