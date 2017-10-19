using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Shots;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Domain.Model.Crew.CrewMembers;

namespace Raccord.Application.Services.Crew.CrewMembers
{
    // Service used for crew member functionality
    public class CrewMemberService : ICrewMemberService
    {
        private readonly ICrewMemberRepository _crewMemberRepository;

        // Initialises a new DayNightService
        public CrewMemberService(ICrewMemberRepository crewMemberRepository)
        {
            if(crewMemberRepository == null)
                throw new ArgumentNullException(nameof(crewMemberRepository));
            
            _crewMemberRepository = crewMemberRepository;
        }

        // Gets all crew members for a project
        public IEnumerable<CrewMemberSummaryDto> GetAllForParent(long departmentID)
        {
            var crewMembers = _crewMemberRepository.GetAllForDepartment(departmentID);

            var dtos = crewMembers.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single crew member by id
        public FullCrewMemberDto Get(long ID)
        {
            var crewMember = _crewMemberRepository.GetFull(ID);

            var dto = crewMember.TranslateFull();

            return dto;
        }

        // Gets a summary of a single crew member
        public CrewMemberSummaryDto GetSummary(long ID)
        {
            var crewMember = _crewMemberRepository.GetSummary(ID);

            var dto = crewMember.TranslateSummary();

            return dto;
        }

        // Adds a crew member
        public long Add(CrewMemberDto dto)
        {
            var crewMember = new CrewMember
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                JobTitle = dto.JobTitle,
                Email = dto.Email,
                Telephone = dto.Telephone,
                DepartmentID = dto.Department.ID,
            };

            _crewMemberRepository.Add(crewMember);
            _crewMemberRepository.Commit();

            return crewMember.ID;
        }

        // Updates a crew member
        public long Update(CrewMemberDto dto)
        {
            var crewMember = _crewMemberRepository.GetSingle(dto.ID);

            crewMember.FirstName = dto.FirstName;
            crewMember.LastName = dto.LastName;
            crewMember.JobTitle = dto.JobTitle;
            crewMember.Email = dto.Email;
            crewMember.Telephone = dto.Telephone;
            crewMember.DepartmentID = dto.Department.ID;

            _crewMemberRepository.Edit(crewMember);
            _crewMemberRepository.Commit();

            return crewMember.ID;
        }

        // Deletes a crew member
        public void Delete(long ID)
        {
            var crewMember = _crewMemberRepository.GetSingle(ID);

            _crewMemberRepository.Delete(crewMember);

            _crewMemberRepository.Commit();
        }
    }
}