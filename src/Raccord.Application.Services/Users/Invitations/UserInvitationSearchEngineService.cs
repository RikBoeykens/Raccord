using System;
using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations;

namespace Raccord.Application.Services.Users.Invitations
{
    // Service to search for users
    public class UserInvitationSearchEngineService : IUserInvitationSearchEngineService
    {
        private readonly EntityType _type = EntityType.UserInvitation;
        private readonly IUserInvitationRepository _userInvitationRepository;

        // Initialises a new ProjectSearchEngineService
        public UserInvitationSearchEngineService(IUserInvitationRepository userInvitationRepository)
        {
            if(userInvitationRepository == null)
                throw new ArgumentNullException(nameof(userInvitationRepository));
            
            _userInvitationRepository = userInvitationRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            if(request.IsAdminSearch)
            {
                var excludeIds = request.GetExcludeGuidIDs(_type);
                var userCount = _userInvitationRepository.SearchCount(request.SearchText, request.UserID, excludeIds);
                var users = _userInvitationRepository.Search(request.SearchText, request.UserID, excludeIds);

                return new SearchTypeResultDto
                {
                    Count = userCount,
                    Type = "Invitations",
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