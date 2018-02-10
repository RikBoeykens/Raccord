using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Breakdowns
{
    // Interface for location functionality
    public interface IBreakdownService : IService<BreakdownDto, BreakdownSummaryDto, FullBreakdownDto>
    {
        IEnumerable<BreakdownSummaryDto> GetAllForParent(long projectID, string userID);
    }
}