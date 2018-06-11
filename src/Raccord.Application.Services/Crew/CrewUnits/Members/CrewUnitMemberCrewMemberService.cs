using System.Linq;
using Raccord.Application.Core.Services.Crew.CrewUnits.Members;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Domain.Model.Crew.CrewMembers;

namespace Raccord.Application.Services.Crew.CrewUnits.Members
{
    // Service for project user crew functionality
    public class CrewUnitMemberCrewMemberService : ICrewUnitMemberCrewMemberService
    {
      private readonly ICrewMemberRepository _crewMemberRepository;

      public CrewUnitMemberCrewMemberService(
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
          CrewUnitMemberID = dto.CrewUnitMemberID
        };

        _crewMemberRepository.Add(newCrewMember);
        _crewMemberRepository.Commit();

        return newCrewMember.ID;
      }

      public void LinkExisting(long crewUnitMemberID, long crewMemberID)
      {
        var crewMember = _crewMemberRepository.GetSingle(crewMemberID);
        crewMember.CrewUnitMemberID = crewUnitMemberID;

        _crewMemberRepository.Edit(crewMember);
        _crewMemberRepository.Commit();
      }

      public void RemoveLink(long crewUnitMemberID, long crewMemberID)
      {
        var crewMember = _crewMemberRepository.FindBy(cm=> cm.ID == crewMemberID && cm.CrewUnitMemberID == crewUnitMemberID).FirstOrDefault();
        if(crewMember!= null)
        {
          crewMember.CrewUnitMemberID = null;

          _crewMemberRepository.Edit(crewMember);
          _crewMemberRepository.Commit();
        }
      }
    }
}