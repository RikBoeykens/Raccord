using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownTypes
{
    // Dto to represent a full breakdown type
    public class FullBreakdownTypeDto: BreakdownTypeDto
    {
        private IEnumerable<BreakdownItemSummaryDto> _breakdownItems;

        // Breakdown items linked to the type
        public IEnumerable<BreakdownItemSummaryDto> BreakdownItems
        {
            get
            {
                return _breakdownItems ?? (_breakdownItems = new List<BreakdownItemSummaryDto>());
            }
            set
            {
                _breakdownItems = value;
            }
        }
    }
}