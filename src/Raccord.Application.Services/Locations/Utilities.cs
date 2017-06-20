using System.Linq;
using Raccord.Application.Core.Services.Locations;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;

namespace Raccord.Application.Services.Locations
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullLocationDto TranslateFull(this ScriptLocation location)
        {
            var dto = new FullLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Scenes = location.Scenes.OrderBy(s=> s.Number).Select(s=> s.TranslateSummary()),
                Images = location.ImageLocations.Select(s=> s.TranslateImage()),
                ProjectID = location.ProjectID,
            };

            return dto;
        }
        public static LocationSummaryDto TranslateSummary(this ScriptLocation location)
        {
            var dto = new LocationSummaryDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                ProjectID = location.ProjectID,
                SceneCount = location.Scenes.Count(),
                PrimaryImage = location.ImageLocations.FirstOrDefault(il=> il.IsPrimaryImage)?.Image.Translate(),
            };

            return dto;
        }

        public static LocationDto Translate(this ScriptLocation location)
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

        public static LinkedLocationDto TranslateLocation(this ImageScriptLocation imageLocation)
        {
            var dto = new LinkedLocationDto
            {
                ID = imageLocation.ScriptLocation.ID,
                Name = imageLocation.ScriptLocation.Name,
                Description = imageLocation.ScriptLocation.Description,
                ProjectID = imageLocation.ScriptLocation.ProjectID,
                LinkID = imageLocation.ID
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this ScriptLocation location)
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