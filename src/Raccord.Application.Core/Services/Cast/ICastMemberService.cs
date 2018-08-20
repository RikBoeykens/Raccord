using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Cast
{
    // Interface for character functionality
    public interface ICastMemberService : IService<CastMemberDto, CastMemberSummaryDto, FullCastMemberDto>, IAllForParentService<CastMemberSummaryDto>
    {
      PagedDataDto<CastMemberSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId);
      AdminFullCastMemberDto GetFullAdmin(long id);
      void AddLink(long castMemberID, long characterID);
      void RemoveLink(long castMemberID, long characterID);
    }
}