using Raccord.Application.Core.Services.Scenes;
using Raccord.Domain.Model.Scenes;
using Raccord.Application.Services.Locations;
using Raccord.Application.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Scenes
{
    // Utilities and helper methods for Scenes
    public static class Utilities
    {
        public static FullSceneDto TranslateFull(this Scene scene)
        {
            var dto = new FullSceneDto
            {
                ID = scene.ID,
                Number = scene.Number,
                Summary = scene.Summary,
                PageLength = scene.PageLength,
                IntExt = scene.IntExt.Translate(),
                Location = scene.Location.Translate(),
                DayNight = scene.DayNight.Translate(),
                ProjectID = scene.ProjectID,
            };

            return dto;
        }
        public static SceneSummaryDto TranslateSummary(this Scene scene)
        {
            var dto = new SceneSummaryDto
            {
                ID = scene.ID,
                Number = scene.Number,
                Summary = scene.Summary,
                PageLength = scene.PageLength,
                IntExt = scene.IntExt.Translate(),
                Location = scene.Location.Translate(),
                DayNight = scene.DayNight.Translate(),
                ProjectID = scene.ProjectID,
            };

            return dto;
        }
        public static SceneDto Translate(this Scene scene)
        {
            var dto = new SceneDto
            {
                ID = scene.ID,
                Number = scene.Number,
                Summary = scene.Summary,
                PageLength = scene.PageLength,
                IntExt = scene.IntExt.Translate(),
                Location = scene.Location.Translate(),
                DayNight = scene.DayNight.Translate(),
                ProjectID = scene.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Scene scene)
        {
            var dto = new SearchResultDto
            {
                ID = scene.ID,
                RouteIDs = new long[]{scene.ProjectID, scene.ID},
                DisplayName = scene.GetDisplaySummary(),
                Info = $"Project: {scene.Project.Title}",
                Type = SearchType.Scene,
            };

            return dto;
        }

        public static string GetDisplaySummary(this Scene scene)
        {
            return $"{scene.Number}. {scene.IntExt.Name} {scene.Location.Name} {scene.DayNight.Name} - {scene.Summary}";
        }
    }
}