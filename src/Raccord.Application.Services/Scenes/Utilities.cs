using Raccord.Application.Core.Services.Scenes;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Locations;
using Raccord.Application.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using System.Linq;
using Raccord.Application.Services.Images;
using Raccord.Domain.Model.Characters;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Application.Services.Scheduling.ScheduleScenes;

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
                Images = scene.ImageScenes.Select(i=> i.TranslateImage()),
                Characters = scene.CharacterScenes.Select(i=> i.TranslateCharacter()),
                BreakdownItems = scene.BreakdownItemScenes.Select(bis=> bis.TranslateBreakdownItem()),
                ScheduleDays = scene.ScheduleScenes.Select(ss=> ss.TranslateDay()),
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
                PrimaryImage = scene.ImageScenes.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
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

        public static LinkedSceneDto TranslateScene(this ImageScene imageScene)
        {
            var dto = new LinkedSceneDto
            {
                ID = imageScene.Scene.ID,
                Number = imageScene.Scene.Number,
                Summary = imageScene.Scene.Summary,
                PageLength = imageScene.Scene.PageLength,
                IntExt = imageScene.Scene.IntExt.Translate(),
                Location = imageScene.Scene.Location.Translate(),
                DayNight = imageScene.Scene.DayNight.Translate(),
                ProjectID = imageScene.Scene.ProjectID,
                LinkID = imageScene.ID,
            };

            return dto;
        }

        public static LinkedSceneDto TranslateScene(this CharacterScene characterScene)
        {
            var dto = new LinkedSceneDto
            {
                ID = characterScene.Scene.ID,
                Number = characterScene.Scene.Number,
                Summary = characterScene.Scene.Summary,
                PageLength = characterScene.Scene.PageLength,
                IntExt = characterScene.Scene.IntExt.Translate(),
                Location = characterScene.Scene.Location.Translate(),
                DayNight = characterScene.Scene.DayNight.Translate(),
                ProjectID = characterScene.Scene.ProjectID,
                PrimaryImage = characterScene.Scene.ImageScenes.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = characterScene.ID,
            };

            return dto;
        }

        public static LinkedSceneDto TranslateScene(this BreakdownItemScene breakdownItemScene)
        {
            var dto = new LinkedSceneDto
            {
                ID = breakdownItemScene.Scene.ID,
                Number = breakdownItemScene.Scene.Number,
                Summary = breakdownItemScene.Scene.Summary,
                PageLength = breakdownItemScene.Scene.PageLength,
                IntExt = breakdownItemScene.Scene.IntExt.Translate(),
                Location = breakdownItemScene.Scene.Location.Translate(),
                DayNight = breakdownItemScene.Scene.DayNight.Translate(),
                ProjectID = breakdownItemScene.Scene.ProjectID,
                PrimaryImage = breakdownItemScene.Scene.ImageScenes.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = breakdownItemScene.ID,
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
                Type = EntityType.Scene,
            };

            return dto;
        }

        public static string GetDisplaySummary(this Scene scene)
        {
            return $"{scene.Number}. {scene.IntExt.Name} {scene.Location.Name} {scene.DayNight.Name} - {scene.Summary}";
        }
    }
}