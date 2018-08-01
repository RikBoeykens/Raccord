using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Characters
{
    // Interface for character functionality
    public interface ICharacterService : IService<CharacterDto, CharacterSummaryDto, FullCharacterDto>, IAllForParentService<CharacterSummaryDto>
    {
        IEnumerable<CharacterSummaryDto> GetAllForCastMember(long castMemberID);
        PagedDataDto<CharacterSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId);
        void Merge(long toID, long mergeID);
    }
}