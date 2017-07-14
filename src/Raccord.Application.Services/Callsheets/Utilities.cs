using System.Linq;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Application.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Services.ShootingDays;
using Raccord.Domain.Model.Callsheets;

namespace Raccord.Application.Services.Callsheets
{
    // Utilities and helper methods for callsheets
    public static class Utilities
    {
        public static FullCallsheetDto TranslateFull(this Callsheet callsheet)
        {
            var dto = new FullCallsheetDto
            {
                ID = callsheet.ID,
                ProjectID = callsheet.ProjectID,
                ShootingDay = callsheet.ShootingDay.Translate(),
                Scenes = callsheet.CallsheetScenes.OrderBy(cs=> cs.SortingOrder).Select(cs=> cs.TranslateScene()),
            };

            return dto;
        }

        public static CallsheetSummaryDto TranslateSummary(this Callsheet callsheet)
        {
            var dto = new CallsheetSummaryDto
            {
                ID = callsheet.ID,
                ProjectID = callsheet.ProjectID,
                ShootingDay = callsheet.ShootingDay.Translate(),
            };

            return dto;
        }

        public static CallsheetDto Translate(this Callsheet callsheet)
        {
            var dto = new CallsheetDto
            {
                ID = callsheet.ID,
                ProjectID = callsheet.ProjectID,
                ShootingDay = callsheet.ShootingDay.Translate(),
            };

            return dto;
        }
    }
}