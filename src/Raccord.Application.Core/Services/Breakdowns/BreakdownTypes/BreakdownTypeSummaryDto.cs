namespace Raccord.Application.Core.Services.Breakdowns.BreakdownTypes
{
    // Dto to represent a summary for a breakdown type
    public class BreakdownTypeSummaryDto: BreakdownTypeDto
    {
        // Full count of items
        public int ItemCount {get; set; }
    }
}