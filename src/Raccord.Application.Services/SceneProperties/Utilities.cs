using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.SceneProperties
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static IntExtDto Translate(this IntExt intExt)
        {
            var dto = new IntExtDto
            {
                ID = intExt.ID,
                Name = intExt.Name,
                Description = intExt.Description,
                Scenes = intExt.Scenes.Select(s=> s.TranslateSummary()),
            };

            return dto;
        }
        public static IntExtSummaryDto TranslateSummary(this IntExt intExt)
        {
            var dto = new IntExtSummaryDto
            {
                ID = intExt.ID,
                Name = intExt.Name,
                Description = intExt.Description,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this IntExt intExt)
        {
            var dto = new SearchResultDto
            {
                RouteIDs = new long[]{intExt.ProjectID, intExt.ID},
                DisplayName = intExt.Name,
                Type = SearchType.IntExt,
            };

            return dto;
        }

        public static DayNightDto Translate(this DayNight dayNight)
        {
            var dto = new DayNightDto
            {
                ID = dayNight.ID,
                Name = dayNight.Name,
                Description = dayNight.Description,
                Scenes = dayNight.Scenes.Select(s=> s.TranslateSummary()),
            };

            return dto;
        }
        public static DayNightSummaryDto TranslateSummary(this DayNight dayNight)
        {
            var dto = new DayNightSummaryDto
            {
                ID = dayNight.ID,
                Name = dayNight.Name,
                Description = dayNight.Description,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this DayNight intExt)
        {
            var dto = new SearchResultDto
            {
                RouteIDs = new long[]{intExt.ProjectID, intExt.ID},
                DisplayName = intExt.Name,
                Type = SearchType.DayNight,
            };

            return dto;
        }
    }
}