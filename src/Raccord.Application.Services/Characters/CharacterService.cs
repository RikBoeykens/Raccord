using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Characters;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Services.Images;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Application.Core.Common.Sorting;
using Raccord.Data.EntityFramework.Repositories.Images;

namespace Raccord.Application.Services.Characters
{
    // Service used for character functionality
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        // Initialises a new CharacterService
        public CharacterService(
            ICharacterRepository characterRepository
            )
        {
            if(characterRepository == null)
                throw new ArgumentNullException(nameof(characterRepository));
            
            _characterRepository = characterRepository;
        }

        // Gets all characters for a project
        public IEnumerable<CharacterSummaryDto> GetAllForProject(long projectID)
        {
            var characters = _characterRepository.GetAllForProject(projectID);

            var dtos = characters.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single character by id
        public FullCharacterDto Get(Int64 ID)
        {
            var character = _characterRepository.GetFull(ID);

            var dto = character.TranslateFull();

            return dto;
        }

        // Gets a summary of a single character
        public CharacterSummaryDto GetSummary(Int64 ID)
        {
            var character = _characterRepository.GetSummary(ID);

            var dto = character.TranslateSummary();

            return dto;
        }

        // Adds a character
        public long Add(CharacterDto dto)
        {
            var character = new Character
            {
                Number = GetNextCharacterNumber(dto.ProjectID),
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };

            _characterRepository.Add(character);
            _characterRepository.Commit();

            return character.ID;
        }

        // Updates a character
        public long Update(CharacterDto dto)
        {
            var character = _characterRepository.GetSingle(dto.ID);

            character.Name = dto.Name;
            character.Description = dto.Description;

            _characterRepository.Edit(character);
            _characterRepository.Commit();

            return character.ID;
        }

        // Deletes a character
        public void Delete(long ID)
        {
            var character = _characterRepository.GetSingle(ID);

            _characterRepository.Delete(character);

            _characterRepository.Commit();
        }

        // Sorts characters
        public void Sort(SortOrderDto order)
        {
            var characters = _characterRepository.GetAllForProject(order.ParentID);

            foreach(var character in characters)
            {
                var orderedIndex = Array.IndexOf(order.SortIDs, character.ID);
                character.Number = orderedIndex != -1 ? orderedIndex : characters.Count();
                _characterRepository.Edit(character);
            }

            _characterRepository.Commit();
        }

        private int GetNextCharacterNumber(long projectID)
        {
            var characters = _characterRepository.GetAllForProject(projectID);
            return characters.Count();
        }
    }
}