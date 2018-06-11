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
    public class CrewUnitInvitationMemberService : ICrewUnitInvitationMemberService
    {
        private readonly ICrewUnitInvitationMemberRepository _crewUnitInvitationMemberRepository;

        // Initialises a new CrewUnitMemberService
        public CrewUnitInvitationMemberService(ICrewUnitInvitationMemberRepository crewUnitInvitationMemberRepository)
        {
            if(crewUnitInvitationMemberRepository == null)
                throw new ArgumentNullException(nameof(crewUnitInvitationMemberRepository));
            
            _crewUnitInvitationMemberRepository = crewUnitInvitationMemberRepository;
        }

        // Gets all crew units for a project user
        public IEnumerable<ProjectUserCrewUnitDto> GetCrewUnits(long projectUserInvitationID)
        {
            var crewUnitMembers = _crewUnitInvitationMemberRepository.GetAllForProjectUserInvitation(projectUserInvitationID);

            var dtos = crewUnitMembers.Select(i=> i.TranslateCrewUnit());

            return dtos;
        }

        public void AddLink(long projectUserInvitationID, long crewUnitID)
        {
            var crewUnitMember = _crewUnitInvitationMemberRepository.FindBy(i=> i.ProjectUserInvitationID == projectUserInvitationID && i.CrewUnitID==crewUnitID);

            if(!crewUnitMember.Any()){
                _crewUnitInvitationMemberRepository.Add(new CrewUnitInvitationMember
                {
                    CrewUnitID = crewUnitID,
                    ProjectUserInvitationID = projectUserInvitationID
                });

                _crewUnitInvitationMemberRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var crewUnitMember = _crewUnitInvitationMemberRepository.GetSingle(ID);

            _crewUnitInvitationMemberRepository.Delete(crewUnitMember);

            _crewUnitInvitationMemberRepository.Commit();
        }
    }
}