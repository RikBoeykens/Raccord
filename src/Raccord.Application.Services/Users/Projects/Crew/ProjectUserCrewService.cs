using System.Linq;
using Raccord.Application.Core.Services.Users.Project.Crew;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Domain.Model.Crew.CrewMembers;

namespace Raccord.Application.Services.Users.Project.Crew
{
    // Service for project user crew functionality
    public class ProjectUserCrewService : IProjectUserCrewService
    {
      private readonly ICrewMemberRepository _crewMemberRepository;

      public ProjectUserCrewService(
        ICrewMemberRepository crewMemberRepository
      ){
        _crewMemberRepository = crewMemberRepository;
      }

      public long Create(CreateUserCrewMemberDto dto)
      {
        var newCrewMember = new CrewMember
        {
          JobTitle = dto.JobTitle,
          DepartmentID = dto.DepartmentID,
          ProjectUserID = dto.ProjectUserID
        };

        _crewMemberRepository.Add(newCrewMember);
        _crewMemberRepository.Commit();

        return newCrewMember.ID;
      }

      public void LinkExisting(long projectUserID, long crewMemberID)
      {
        var crewMember = _crewMemberRepository.GetSingle(crewMemberID);
        crewMember.ProjectUserID = projectUserID;

        _crewMemberRepository.Edit(crewMember);
        _crewMemberRepository.Commit();
      }

      public void RemoveLink(long projectUserID, long crewMemberID)
      {
        var crewMember = _crewMemberRepository.FindBy(cm=> cm.ID == crewMemberID && cm.ProjectUserID == projectUserID).FirstOrDefault();
        if(crewMember!= null)
        {
          crewMember.ProjectUserID = null;

          _crewMemberRepository.Edit(crewMember);
          _crewMemberRepository.Commit();
        }
      }
    }
}