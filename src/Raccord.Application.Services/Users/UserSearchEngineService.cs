using System;
using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;
using Raccord.Application.Core.Services.Users;
using Raccord.Data.EntityFramework.Repositories.Users;

namespace Raccord.Application.Services.Users
{
    // Service to search for users
    public class UserSearchEngineService : IUserSearchEngineService
    {
        private readonly EntityType _type = EntityType.User;
        private readonly IUserRepository _userRepository;

        // Initialises a new ProjectSearchEngineService
        public UserSearchEngineService(IUserRepository userRepository)
        {
            if(userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            
            _userRepository = userRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            if(request.IsAdminSearch)
            {
                var excludeIds = request.GetExcludeStringIDs(_type);
                var userCount = _userRepository.SearchCount(request.SearchText, request.UserID, excludeIds);
                var users = _userRepository.Search(request.SearchText, request.UserID, excludeIds);

                return new SearchTypeResultDto
                {
                    Count = userCount,
                    Type = "Users",
                    Results = users.Select(p=> p.TranslateToSearchResult()),
                };
            }
            else
            {
                return new SearchTypeResultDto();
            }
            
        }
    }
}