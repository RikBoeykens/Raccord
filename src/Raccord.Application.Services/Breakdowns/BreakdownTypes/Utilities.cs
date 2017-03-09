using System.Linq;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Services.Breakdowns.BreakdownTypes
{
    // Utilities and helper methods for breakdown types
    public static class Utilities
    {
        public static FullBreakdownTypeDto TranslateFull(this BreakdownType breakdownType)
        {
            var dto = new FullBreakdownTypeDto
            {
                ID = breakdownType.ID,
                Name = breakdownType.Name,
                Description = breakdownType.Description,
                ProjectID = breakdownType.ProjectID,
            };

            return dto;
        }
        public static BreakdownTypeSummaryDto TranslateSummary(this BreakdownType breakdownType)
        {
            var dto = new BreakdownTypeSummaryDto
            {
                ID = breakdownType.ID,
                Name = breakdownType.Name,
                Description = breakdownType.Description,
                ProjectID = breakdownType.ProjectID,
                ItemCount = 0,
            };

            return dto;
        }

        public static BreakdownTypeDto Translate(this BreakdownType breakdownType)
        {
            var dto = new BreakdownTypeDto
            {
                ID = breakdownType.ID,
                Name = breakdownType.Name,
                Description = breakdownType.Description,
                ProjectID = breakdownType.ProjectID,
            };

            return dto;
        }
    }
}