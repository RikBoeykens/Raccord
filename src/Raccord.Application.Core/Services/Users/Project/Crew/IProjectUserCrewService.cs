namespace Raccord.Application.Core.Services.Users.Project.Crew
{
    // Interface for project user crew functionality
    public interface IProjectUserCrewService
    {
      long Create(CreateUserCrewMemberDto dto);
      void LinkExisting(long projectUserID, long crewMemberID);
      void RemoveLink(long projectUserID, long crewMemberID);
    }
}