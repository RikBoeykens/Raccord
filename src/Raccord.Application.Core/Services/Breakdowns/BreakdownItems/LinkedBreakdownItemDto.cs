namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a breakdown item that's linked to something
    public class LinkedBreakdownItemDto: BreakdownItemSummaryDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}