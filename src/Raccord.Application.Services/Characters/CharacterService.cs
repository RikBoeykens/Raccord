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
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Common.Paging;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Characters
{
    // Service used for character functionality
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ICommentRepository _commentRepository;

        // Initialises a new CharacterService
        public CharacterService(
            ICharacterRepository characterRepository,
            ICommentRepository commentRepository
            )
        {
            _characterRepository = characterRepository;
            _commentRepository = commentRepository;
        }

        // Gets all characters for a project
        public IEnumerable<CharacterSummaryDto> GetAllForParent(long projectID)
        {
            var characters = _characterRepository.GetAllForProject(projectID);

            var dtos = characters.Select(l => l.TranslateSummary())
                                .OrderBy(c => c.Number==0)
                                .ThenBy(c => c.Number).ThenBy(c  => c.SceneCount);

            return dtos;
        }

        // Gets all characters for a project
        public IEnumerable<CharacterSummaryDto> GetAllForCastMember(long castMemberID)
        {
            var characters = _characterRepository.GetAllForCastMember(castMemberID);

            var dtos = characters.Select(l => l.TranslateSummary());

            return dtos;
        }

        public PagedDataDto<CharacterSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId)
        {
            var characters = _characterRepository.GetAllForProject(projectId);
            return characters.GetPaged<Character, CharacterSummaryDto>(paginationRequest, x => x.TranslateSummary());
        }

        // Gets a single character by id
        public FullCharacterDto Get(Int64 ID)
        {
            var character = _characterRepository.GetFull(ID);

            var comments = _commentRepository.GetForParent(character.ID, ParentCommentType.Character).ToList();

            var dto = character.TranslateFull(comments);

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
                Number = dto.Number,
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

            character.Number = dto.Number;
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

        public void Merge(long toID, long mergeID)
        {
            var toCharacter = _characterRepository.GetFull(toID);
            var mergeCharacter = _characterRepository.GetFull(mergeID);

            var sceneList = mergeCharacter.CharacterScenes.ToList();

            foreach(var scene in sceneList)
            {
                if(!toCharacter.CharacterScenes.Any(cs=> cs.SceneID == scene.SceneID))
                {
                    toCharacter.CharacterScenes.Add(new CharacterScene{ SceneID = scene.SceneID});
                }
            }

            var imageList = mergeCharacter.ImageCharacters.ToList();

            foreach(var image in imageList)
            {
                if(!toCharacter.ImageCharacters.Any(cs=> cs.ImageID == image.ImageID))
                {
                    toCharacter.ImageCharacters.Add(new ImageCharacter{ImageID = image.ImageID});
                }
            }
            _characterRepository.Edit(toCharacter);
            _characterRepository.Delete(mergeCharacter);

            _characterRepository.Commit();
        }

    }
}