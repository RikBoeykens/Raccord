using System.Linq;
using Raccord.Application.Core.Services.Crew.CrewUnits.Members;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Domain.Model.Crew.CrewMembers;

namespace Raccord.Application.Services.Crew.CrewUnits.Members
{
    // Service for project user crew functionality
    public class CrewUnitInvitationMemberCrewMemberService : ICrewUnitInvitationMemberCrewMemberService
    {
      private readonly ICrewMemberRepository _crewMemberRepository;

      public CrewUnitInvitationMemberCrewMemberService(
        ICrewMemberRepository crewMemberRepository
      ){
        _crewMemberRepository = crewMemberRepository;
      }

      public long Create(CreateCrewUnitMemberCrewMemberDto dto)
      {
        var newCrewMember = new CrewMember
        {
          JobTitle = dto.JobTitle,
          DepartmentID = dto.DepartmentID,
          CrewUnitInvitationMemberID = dto.LinkID
        };

        _crewMemberRepository.Add(newCrewMember);
        _crewMemberRepository.Commit();

        return newCrewMember.ID;
      }

      public void LinkExisting(long crewUnitInvitationMemberID, long crewMemberID)
      {
        var crewMember = _crewMemberRepository.GetSingle(crewMemberID);
        crewMember.CrewUnitInvitationMemberID = crewUnitInvitationMemberID;

        _crewMemberRepository.Edit(crewMember);
        _crewMemberRepository.Commit();
      }

      public void RemoveLink(long crewUnitInvitationMemberID, long crewMemberID)
      {
        var crewMember = _crewMemberRepository.FindBy(cm=> cm.ID == crewMemberID && cm.CrewUnitInvitationMemberID == crewUnitInvitationMemberID).FirstOrDefault();
        if(crewMember!= null)
        {
          crewMember.CrewUnitInvitationMemberID = null;

          _crewMemberRepository.Edit(crewMember);
          _crewMemberRepository.Commit();
        }
      }
    }
}