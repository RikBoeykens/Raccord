namespace Raccord.Application.Core.Services.Crew.CrewMembers
{
    // Interface for crew member functionality
    public interface ICrewMemberService : IService<CrewMemberDto, CrewMemberSummaryDto, FullCrewMemberDto>, IAllForParentService<CrewMemberSummaryDto>
    {
    }
}