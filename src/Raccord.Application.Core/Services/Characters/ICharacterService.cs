using System.Collections.Generic;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Characters
{
    // Interface for character functionality
    public interface ICharacterService : IService<CharacterDto, CharacterSummaryDto, FullCharacterDto>, IAllForParentService<CharacterSummaryDto>
    {
        IEnumerable<CharacterSummaryDto> GetAllForCastMember(long castMemberID);
        void Merge(long toID, long mergeID);
    }
}