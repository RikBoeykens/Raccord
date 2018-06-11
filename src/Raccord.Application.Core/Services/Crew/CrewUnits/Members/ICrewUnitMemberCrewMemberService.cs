namespace Raccord.Application.Core.Services.Crew.CrewUnits.Members
{
    // Interface for project user crew functionality
    public interface ICrewUnitMemberCrewMemberService
    {
      long Create(CreateCrewUnitMemberCrewMemberDto dto);
      void LinkExisting(long crewUnitMemberID, long crewMemberID);
      void RemoveLink(long crewUnitMemberID, long crewMemberID);
    }
}