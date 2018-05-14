using System;
using System.Linq;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.Crew.CrewMembers
{
    // Service to search for crew members
    public class CrewMemberSearchEngineService : ICrewMemberSearchEngineService
    {
        private readonly EntityType _type = EntityType.CrewMember;
        private readonly ICrewMemberRepository _crewMemberRepository;

        // Initialises a new CrewMemberSearchEngineService
        public CrewMemberSearchEngineService(ICrewMemberRepository crewMemberRepository)
        {
            if(crewMemberRepository == null)
                throw new ArgumentNullException(nameof(crewMemberRepository));
            
            _crewMemberRepository = crewMemberRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeIDs(_type);
            var crewCount = _crewMemberRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var crewMembers = _crewMemberRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = crewCount,
                Type = "Crew",
                Results = crewMembers.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}