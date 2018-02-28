using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Crew.CrewUnits.Members;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Application.Services.Users.Projects;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members;
using Raccord.Domain.Model.Crew.CrewUnits;

namespace Raccord.Application.Services.Crew.CrewUnits.Members
{
    // Service used for crew unit member functionality
    public class CrewUnitMemberService : ICrewUnitMemberService
    {
        private readonly ICrewUnitMemberRepository _crewUnitMemberRepository;

        // Initialises a new CrewUnitMemberService
        public CrewUnitMemberService(ICrewUnitMemberRepository crewUnitMemberRepository)
        {
            if(crewUnitMemberRepository == null)
                throw new ArgumentNullException(nameof(crewUnitMemberRepository));
            
            _crewUnitMemberRepository = crewUnitMemberRepository;
        }

        // Gets all crew units for a project user
        public IEnumerable<ProjectUserCrewUnitDto> GetCrewUnits(long projectUserID)
        {
            var crewUnitMembers = _crewUnitMemberRepository.GetAllForProjectUser(projectUserID);

            var dtos = crewUnitMembers.Select(i=> i.TranslateCrewUnit());

            return dtos;
        }

        // Gets all project users for a crew unit
        public IEnumerable<LinkedProjectUserUserDto> GetUsers(long crewUnitID)
        {
            var crewUnitMembers = _crewUnitMemberRepository.GetAllForUnit(crewUnitID);

            var dtos = crewUnitMembers.Select(i=> i.TranslateProjectUser());

            return dtos;
        }

        public void AddLink(long projectUserID, long crewUnitID)
        {
            var crewUnitMember = _crewUnitMemberRepository.FindBy(i=> i.ProjectUserID == projectUserID && i.CrewUnitID==crewUnitID);

            if(!crewUnitMember.Any()){
                _crewUnitMemberRepository.Add(new CrewUnitMember
                {
                    CrewUnitID = crewUnitID,
                    ProjectUserID = projectUserID
                });

                _crewUnitMemberRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var crewUnitMember = _crewUnitMemberRepository.GetSingle(ID);

            _crewUnitMemberRepository.Delete(crewUnitMember);

            _crewUnitMemberRepository.Commit();
        }
    }
}