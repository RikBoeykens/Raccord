using System;
using System.Linq;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Cast;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.Cast
{
    // Service to search for cast members
    public class CastMemberSearchEngineService : ICastMemberSearchEngineService
    {
        private readonly EntityType _type = EntityType.CastMember;
        private readonly ICastMemberRepository _castMemberRepository;

        // Initialises a new CastMemberSearchEngineService
        public CastMemberSearchEngineService(ICastMemberRepository castMemberRepository)
        {
            if(castMemberRepository == null)
                throw new ArgumentNullException(nameof(castMemberRepository));
            
            _castMemberRepository = castMemberRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var castCount = _castMemberRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var castMembers = _castMemberRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = castCount,
                Type = "Cast",
                Results = castMembers.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}