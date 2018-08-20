using System.Collections.Generic;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Interface for location functionality
    public interface ICallsheetService : IAllForParentService<CallsheetSummaryDto>
    {
        // Returns a single full instance
        FullCallsheetDto Get(long ID, string userID);

        // Returns the summary of a single instance
        CallsheetSummaryDto GetSummary(long ID);

        // Adds a single instance
        long Add(CallsheetDto dto);
        
        // Updates a single instance
        long Update(CallsheetDto dto);

        // Deletes a single instance
        void Delete(long ID);
        PagedDataDto<CallsheetCrewUnitDto> GetForProject(long projectID, PaginationRequestDto requestDto);
        PagedDataDto<CallsheetSummaryDto> GetForCrewUnit(long projectID, PaginationRequestDto requestDto);
    }
}