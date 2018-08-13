using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Shots;
using Raccord.Application.Core.Services.Cast;
using Raccord.Data.EntityFramework.Repositories.Cast;
using Raccord.Domain.Model.Cast;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Application.Core.Common.Paging;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;

namespace Raccord.Application.Services.Cast
{
    // Service used for cast member functionality
    public class CastMemberService : ICastMemberService
    {
        private readonly ICastMemberRepository _castMemberRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IShootingDayRepository _shootingDayRepository;

        // Initialises a new DayNightService
        public CastMemberService(
            ICastMemberRepository castMemberRepository,
            ICharacterRepository characterRepository,
            IShootingDayRepository shootingDayRepository
            )
        {
            _castMemberRepository = castMemberRepository;
            _characterRepository = characterRepository;
            _shootingDayRepository = shootingDayRepository;
        }

        // Gets all cast members for a project
        public IEnumerable<CastMemberSummaryDto> GetAllForParent(long projectID)
        {
            var castMembers = _castMemberRepository.GetAllForProject(projectID);

            var dtos = castMembers.Select(l => l.TranslateSummary()).ToList();

            return dtos;
        }

        public PagedDataDto<CastMemberSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId)
        {
            var castMembers = _castMemberRepository.GetAllForProject(projectId);
            return castMembers.GetPaged<CastMember, CastMemberSummaryDto>(paginationRequest, x => x.TranslateSummary());
        }

        // Gets a single cast member by id
        public FullCastMemberDto Get(long ID)
        {
            var castMember = _castMemberRepository.GetFull(ID);

            var shootingDays = _shootingDayRepository.GetAllForCharacters(castMember.Characters.Select(c => c.ID).ToArray()).ToList();

            var dto = castMember.TranslateFull(shootingDays);

            return dto;
        }

        // Gets a single cast member by id
        public AdminFullCastMemberDto GetFullAdmin(long ID)
        {
            var castMember = _castMemberRepository.GetFull(ID);

            var dto = castMember.TranslateFullAdmin();

            return dto;
        }

        // Gets a summary of a single cast member
        public CastMemberSummaryDto GetSummary(long ID)
        {
            var castMember = _castMemberRepository.GetSummary(ID);

            var dto = castMember.TranslateSummary();

            return dto;
        }

        // Adds a cast member
        public long Add(CastMemberDto dto)
        {
            var castMember = new CastMember
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Telephone = dto.Telephone,
                ProjectID = dto.ProjectID
            };

            _castMemberRepository.Add(castMember);
            _castMemberRepository.Commit();

            return castMember.ID;
        }

        // Updates a cast member
        public long Update(CastMemberDto dto)
        {
            var castMember = _castMemberRepository.GetSingle(dto.ID);

            castMember.FirstName = dto.FirstName;
            castMember.LastName = dto.LastName;
            castMember.Email = dto.Email;
            castMember.Telephone = dto.Telephone;

            _castMemberRepository.Edit(castMember);
            _castMemberRepository.Commit();

            return castMember.ID;
        }

        // Deletes a cast member
        public void Delete(long ID)
        {
            var castMember = _castMemberRepository.GetSingle(ID);

            _castMemberRepository.Delete(castMember);

            _castMemberRepository.Commit();
        }

        public void AddLink(long castMemberID, long characterID)
        {
            var character = _characterRepository.GetSingle(characterID);

            character.CastMemberID = castMemberID;

            _characterRepository.Edit(character);
            _characterRepository.Commit();
        }

        public void RemoveLink(long castMemberID, long characterID)
        {
            var character = _characterRepository.GetSingle(characterID);

            character.CastMemberID = null;

            _characterRepository.Edit(character);
            _characterRepository.Commit();
        }
    }
}