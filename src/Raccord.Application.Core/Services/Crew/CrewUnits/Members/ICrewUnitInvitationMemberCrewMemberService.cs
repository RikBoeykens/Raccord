namespace Raccord.Application.Core.Services.Crew.CrewUnits.Members
{
    // Interface for project user crew functionality
    public interface ICrewUnitInvitationMemberCrewMemberService
    {
      long Create(CreateCrewUnitInvitationMemberCrewMemberDto dto);
      void LinkExisting(long crewUnitInvitationMemberID, long crewMemberID);
      void RemoveLink(long crewUnitInvitationMemberID, long crewMemberID);
    }
}