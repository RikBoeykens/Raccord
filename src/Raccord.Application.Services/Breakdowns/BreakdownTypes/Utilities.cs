using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Services.Breakdowns.BreakdownItems;
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
                Breakdown = breakdownType.Breakdown.TranslateSummary(),
                BreakdownItems = breakdownType.BreakdownItems.Select(bi=> bi.TranslateSummary())
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
                BreakdownID = breakdownType.BreakdownID,
                ItemCount = breakdownType.BreakdownItems.Count(),
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
                BreakdownID = breakdownType.BreakdownID,
            };

            return dto;
        }

        public static CallsheetBreakdownTypeDto TranslateCallsheet(this BreakdownType breakdownType, IEnumerable<CallsheetBreakdownItemSceneDto> scenes)
        {
            if(breakdownType == null)
            {
                return null;
            }

            var dto = new CallsheetBreakdownTypeDto
            {
                ID = breakdownType.ID,
                Name = breakdownType.Name,
                Description = breakdownType.Description,
                Scenes = scenes
            };

            return dto;
        }
    }
}