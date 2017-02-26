using System.Linq;
using Raccord.Application.Core.Services.Locations;
using Raccord.Domain.Model.Locations;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Locations
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullLocationDto TranslateFull(this Location location)
        {
            var dto = new FullLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Scenes = location.Scenes.Select(s=> s.TranslateSummary()),
                ProjectID = location.ProjectID,
            };

            return dto;
        }
        public static LocationSummaryDto TranslateSummary(this Location location)
        {
            var dto = new LocationSummaryDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                ProjectID = location.ProjectID,
                SceneCount = location.Scenes.Count(),
            };

            return dto;
        }

        public static LocationDto Translate(this Location location)
        {
            var dto = new LocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                ProjectID = location.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Location location)
        {
            var dto = new SearchResultDto
            {
                ID = location.ID,
                RouteIDs = new long[]{location.ProjectID, location.ID},
                DisplayName = location.Name,
                Info = $"Project: {location.Project.Title}",
                Type = EntityType.Location,
            };

            return dto;
        }
    }
}