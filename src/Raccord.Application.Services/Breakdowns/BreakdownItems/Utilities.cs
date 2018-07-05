using System.Linq;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Common.Routing;

namespace Raccord.Application.Services.Breakdowns.BreakdownItems
{
    // Utilities and helper methods for Breakdown items
    public static class Utilities
    {
        public static FullBreakdownItemDto TranslateFull(this BreakdownItem breakdownItem)
        {
            var dto = new FullBreakdownItemDto
            {
                ID = breakdownItem.ID,
                Name = breakdownItem.Name,
                Description = breakdownItem.Description,
                Type = breakdownItem.BreakdownType.Translate(),
                Breakdown = breakdownItem.Breakdown.TranslateSummary(),
                Scenes = breakdownItem.BreakdownItemScenes.OrderBy(s=> s.Scene.SortingOrder)
                                                            .Select(s=> s.TranslateScene()),
                Images = breakdownItem.ImageBreakdownItems.Select(s=> s.TranslateImage()),
            };

            return dto;
        }
        public static BreakdownItemSummaryDto TranslateSummary(this BreakdownItem breakdownItem)
        {
            var dto = new BreakdownItemSummaryDto
            {
                ID = breakdownItem.ID,
                Name = breakdownItem.Name,
                Description = breakdownItem.Description,
                BreakdownID = breakdownItem.BreakdownID,
                BreakdownTypeID = breakdownItem.BreakdownTypeID,
                SceneCount = breakdownItem.BreakdownItemScenes.Count(),
                PrimaryImage = breakdownItem.ImageBreakdownItems.FirstOrDefault(il=> il.IsPrimaryImage)?.Image.Translate(),
            };

            return dto;
        }

        public static BreakdownItemDto Translate(this BreakdownItem breakdownItem)
        {
            var dto = new BreakdownItemDto
            {
                ID = breakdownItem.ID,
                Name = breakdownItem.Name,
                Description = breakdownItem.Description,
                BreakdownID = breakdownItem.BreakdownID,
                BreakdownTypeID = breakdownItem.BreakdownTypeID,
            };

            return dto;
        }

        public static LinkedBreakdownItemDto TranslateBreakdownItem(this ImageBreakdownItem imageBreakdownItem)
        {
            var dto = new LinkedBreakdownItemDto
            {
                ID = imageBreakdownItem.BreakdownItem.ID,
                Name = imageBreakdownItem.BreakdownItem.Name,
                Description = imageBreakdownItem.BreakdownItem.Description,
                Type = imageBreakdownItem.BreakdownItem.BreakdownType.Translate(),
                Breakdown = imageBreakdownItem.BreakdownItem.Breakdown.Translate(),
                LinkID = imageBreakdownItem.ID
            };

            return dto;
        }

        public static SceneBreakdownItemDto TranslateBreakdownItem(this BreakdownItemScene breakdownItemScene)
        {
            var dto = new SceneBreakdownItemDto
            {
                ID = breakdownItemScene.BreakdownItem.ID,
                Name = breakdownItemScene.BreakdownItem.Name,
                Description = breakdownItemScene.BreakdownItem.Description,
                Type = breakdownItemScene.BreakdownItem.BreakdownType.Translate(),
                LinkID = breakdownItemScene.ID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this BreakdownItem breakdownItem)
        {
            var dto = new SearchResultDto
            {
                ID = breakdownItem.ID,
                DisplayName = $"{breakdownItem.Name} ({breakdownItem.Breakdown.Name} - {breakdownItem.BreakdownType.Name})",
                Info = $"Project: {breakdownItem.BreakdownType.Breakdown.Project.Title}",
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{breakdownItem.BreakdownType.Breakdown.ProjectID, breakdownItem.BreakdownID, breakdownItem.ID},
                    Type = EntityType.BreakdownItem
                }
            };

            return dto;
        }

        public static CallsheetBreakdownItemDto TranslateCallsheet(this BreakdownItem breakdownItem)
        {
            var dto = new CallsheetBreakdownItemDto
            {
                ID = breakdownItem.ID,
                Name = breakdownItem.Name,
                Description = breakdownItem.Description,
            };

            return dto;
        }
    }
}