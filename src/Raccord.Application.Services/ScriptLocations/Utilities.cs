using System.Linq;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Locations.LocationSets;

namespace Raccord.Application.Services.ScriptLocations
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullScriptLocationDto TranslateFull(this ScriptLocation location)
        {
            var dto = new FullScriptLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Scenes = location.Scenes.OrderBy(s=> s.Number).Select(s=> s.TranslateSummary()),
                Images = location.ImageLocations.Select(s=> s.TranslateImage()),
                Sets = location.LocationSets.Select(ls=> ls.TranslateLocation()),
                ProjectID = location.ProjectID,
            };

            return dto;
        }
        public static ScriptLocationSummaryDto TranslateSummary(this ScriptLocation location)
        {
            var dto = new ScriptLocationSummaryDto
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

        public static ScriptLocationDto Translate(this ScriptLocation location)
        {
            var dto = new ScriptLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                ProjectID = location.ProjectID,
            };

            return dto;
        }

        public static LinkedScriptLocationDto TranslateLocation(this ImageScriptLocation imageLocation)
        {
            var dto = new LinkedScriptLocationDto
            {
                ID = imageLocation.ScriptLocation.ID,
                Name = imageLocation.ScriptLocation.Name,
                Description = imageLocation.ScriptLocation.Description,
                ProjectID = imageLocation.ScriptLocation.ProjectID,
                LinkID = imageLocation.ID
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this ScriptLocation scriptLocation)
        {
            var dto = new SearchResultDto
            {
                ID = scriptLocation.ID,
                RouteIDs = new long[]{scriptLocation.ProjectID, scriptLocation.ID},
                DisplayName = scriptLocation.Name,
                Info = $"Project: {scriptLocation.Project.Title}",
                Type = EntityType.ScriptLocation,
            };

            return dto;
        }
    }
}