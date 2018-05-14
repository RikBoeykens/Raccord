namespace Raccord.Application.Core.Services.Crew.CrewUnits.Members
{
    // Interface for project user crew functionality
    public interface IUnitCrewMemberService
    {
      long Create(CreateUnitCrewMemberDto dto);
      void LinkExisting(long crewUnitMemberID, long crewMemberID);
      void RemoveLink(long crewUnitMemberID, long crewMemberID);
    }
}