using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownTypes
{
    // Dto to represent a full breakdown type
    public class FullBreakdownTypeDto: BaseBreakdownTypeDto
    {
        private BreakdownSummaryDto _breakdown;
        private IEnumerable<BreakdownItemSummaryDto> _breakdownItems;

        // Breakdown linked to the type
        public BreakdownSummaryDto Breakdown
        {
            get
            {
                return _breakdown ?? (_breakdown = new BreakdownSummaryDto());
            }
            set
            {
                _breakdown = value;
            }
        }

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