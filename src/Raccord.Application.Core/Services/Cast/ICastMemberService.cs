namespace Raccord.Application.Core.Services.Cast
{
    // Interface for character functionality
    public interface ICastMemberService : IService<CastMemberDto, CastMemberSummaryDto, FullCastMemberDto>, IAllForParentService<CastMemberSummaryDto>
    {
      void AddLink(long castMemberID, long characterID);
      void RemoveLink(long castMemberID, long characterID);
    }
}