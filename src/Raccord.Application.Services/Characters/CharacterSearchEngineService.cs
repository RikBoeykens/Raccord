using System;
using System.Linq;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Characters
{
    // Service to search for characters
    public class CharacterSearchEngineService : ICharacterSearchEngineService
    {
        private readonly ICharacterRepository _characterRepository;

        // Initialises a new CharacterSearchEngineService
        public CharacterSearchEngineService(ICharacterRepository sceneRepository)
        {
            if(sceneRepository == null)
                throw new ArgumentNullException(nameof(sceneRepository));
            
            _characterRepository = sceneRepository;
        }

        public new EntityType GetType()
        {
            return EntityType.Character;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var characterCount = _characterRepository.SearchCount(request.SearchText, request.ProjectID);
            var characters = _characterRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = characterCount,
                Type = "Character",
                Results = characters.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}