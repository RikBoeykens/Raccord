using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Breakdowns
{
    // Interface for location functionality
    public interface IBreakdownService : IService<BreakdownDto, BreakdownSummaryDto, FullBreakdownDto>
    {
        IEnumerable<BreakdownSummaryDto> GetAllForParent(long projectID, string userID);
        SelectedBreakdownDto GetForProjectUser(long projectID, string userID);
        void SelectBreakdown(long projectID, string userID, long breakdownID);
        void TogglePublishBreakdown(PublishBreakdownDto dto);
        void SetDefaultProjectBreakdown(long projectID, long breakdownID);
    }
}