using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a breakdown item
    public class BreakdownItemDto : BaseBreakdownItemDto
    {
        /// <summary>
        /// ID of the linked breakdown
        /// </summary>
        /// <returns></returns>
        public long BreakdownID { get; set; }
        
        /// <summary>
        /// ID of the linked breakdown type
        /// </summary>
        /// <returns></returns>
        public long BreakdownTypeID { get; set; }
    }
}