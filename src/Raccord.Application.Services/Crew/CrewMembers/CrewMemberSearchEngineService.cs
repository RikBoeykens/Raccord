using System;
using System.Linq;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Crew.CrewMembers
{
    // Service to search for crew members
    public class CrewMemberSearchEngineService : ICrewMemberSearchEngineService
    {
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
            return EntityType.CrewMember;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var crewCount = _crewMemberRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch);
            var crewMembers = _crewMemberRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch);

            return new SearchTypeResultDto
            {
                Count = crewCount,
                Type = "Crew",
                Results = crewMembers.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}