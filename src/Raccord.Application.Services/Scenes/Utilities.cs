using Raccord.Application.Core.Services.Scenes;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.ScriptLocations;
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
using Raccord.Domain.Model.Scheduling;
using Raccord.Application.Services.Shots.Slates;
using System.Collections.Generic;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Application.Services.ShootingDays;
using Raccord.Domain.Model.Breakdowns;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Application.Services.Breakdowns;
using Raccord.Application.Core.Common.Routing;

namespace Raccord.Application.Services.Scenes
{
    // Utilities and helper methods for Scenes
    public static class Utilities
    {
        public static FullSceneDto TranslateFull(this Scene scene, IEnumerable<ShootingDay> shootingDays, Breakdown breakdown)
        {
            SceneBreakdownDto breakdownDto = null;
            if(breakdown!=null)
            {
                breakdownDto = breakdown.TranslateScene(
                    scene.BreakdownItemScenes
                        .Where(bis=> bis.BreakdownItem.BreakdownID == breakdown.ID).ToList()
                        .Select(bis=> bis.TranslateBreakdownItem())
                    );
            }

            var dto = new FullSceneDto
            {
                ID = scene.ID,
                Number = scene.Number,
                Summary = scene.Summary,
                PageLength = scene.PageLength,
                Timing = scene.Timing,
                SceneIntro = scene.SceneIntro.Translate(),
                ScriptLocation = scene.ScriptLocation.Translate(),
                TimeOfDay = scene.TimeOfDay.Translate(),
                Images = scene.ImageScenes.Select(i=> i.TranslateImage()),
                Characters = scene.CharacterScenes.Select(i=> i.TranslateCharacter()),
                BreakdownInfo = breakdownDto,
                ShootingDays = shootingDays.Select(sd=> sd.TranslateSceneInfo(scene.ID)).OrderBy(sd=> sd.Type).ThenBy(sd=> sd.Date),
                Slates = scene.Slates.Select(s=> s.TranslateSummary()),
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
                Timing = scene.Timing,
                SceneIntro = scene.SceneIntro.Translate(),
                ScriptLocation = scene.ScriptLocation.Translate(),
                TimeOfDay = scene.TimeOfDay.Translate(),
                /*PrimaryImage = scene.ImageScenes.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),*/
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
                Timing = scene.Timing,
                SceneIntro = scene.SceneIntro.Translate(),
                ScriptLocation = scene.ScriptLocation.Translate(),
                TimeOfDay = scene.TimeOfDay.Translate(),
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
                Timing = imageScene.Scene.Timing,
                SceneIntro = imageScene.Scene.SceneIntro.Translate(),
                ScriptLocation = imageScene.Scene.ScriptLocation.Translate(),
                TimeOfDay = imageScene.Scene.TimeOfDay.Translate(),
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
                Timing = characterScene.Scene.Timing,
                SceneIntro = characterScene.Scene.SceneIntro.Translate(),
                ScriptLocation = characterScene.Scene.ScriptLocation.Translate(),
                TimeOfDay = characterScene.Scene.TimeOfDay.Translate(),
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
                Timing = breakdownItemScene.Scene.Timing,
                SceneIntro = breakdownItemScene.Scene.SceneIntro.Translate(),
                ScriptLocation = breakdownItemScene.Scene.ScriptLocation.Translate(),
                TimeOfDay = breakdownItemScene.Scene.TimeOfDay.Translate(),
                ProjectID = breakdownItemScene.Scene.ProjectID,
                PrimaryImage = breakdownItemScene.Scene.ImageScenes.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = breakdownItemScene.ID,
            };

            return dto;
        }

        public static LinkedSceneDto TranslateLinkedScene(this ScheduleScene scheduleScene)
        {
            var dto = new LinkedSceneDto
            {
                ID = scheduleScene.Scene.ID,
                Number = scheduleScene.Scene.Number,
                Summary = scheduleScene.Scene.Summary,
                Timing = scheduleScene.Scene.Timing,
                PageLength = scheduleScene.Scene.PageLength,
                SceneIntro = scheduleScene.Scene.SceneIntro.Translate(),
                ScriptLocation = scheduleScene.Scene.ScriptLocation.Translate(),
                TimeOfDay = scheduleScene.Scene.TimeOfDay.Translate(),
                ProjectID = scheduleScene.Scene.ProjectID,
                PrimaryImage = scheduleScene.Scene.ImageScenes.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = scheduleScene.ID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Scene scene)
        {
            var dto = new SearchResultDto
            {
                ID = scene.ID,
                DisplayName = scene.GetDisplaySummary(),
                Info = $"Project: {scene.Project.Title}",
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{scene.ProjectID, scene.ID},
                    Type = EntityType.Scene,
                }
            };

            return dto;
        }

        public static string GetDisplaySummary(this Scene scene)
        {
            if(!scene.SceneIntroID.HasValue || !scene.ScriptLocationID.HasValue || !scene.TimeOfDayID.HasValue)
            {
                return $"{scene.Number}. {scene.Summary}";
            }
            return $"{scene.Number}. {scene.SceneIntro.Name} {scene.ScriptLocation.Name} {scene.TimeOfDay.Name} - {scene.Summary}";
        }
    }
}