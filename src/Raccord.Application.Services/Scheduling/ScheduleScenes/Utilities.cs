using System.Linq;
using Raccord.Application.Core.Services.Locations;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Services.Scheduling.ScheduleDays;
using Raccord.Application.Services.Characters;

namespace Raccord.Application.Services.Scheduling.ScheduleScenes
{
    // Utilities and helper methods for Schedule Scenes
    public static class Utilities
    {
        public static FullScheduleSceneDto TranslateFull(this ScheduleScene scheduleScene)
        {
            var dto = new FullScheduleSceneDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                SceneScheduledPageLength = scheduleScene.Scene.ScheduleScenes.Sum(ss=> ss.PageLength),
                ScheduleDay = scheduleScene.ScheduleDay.TranslateSummary(),
                Scene = scheduleScene.Scene.TranslateSummary(),
                Characters = scheduleScene.Characters.Select(c=> c.TranslateCharacter()),
            };

            return dto;
        }
        public static ScheduleSceneDayDto TranslateDay(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneDayDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                ScheduleDay = scheduleScene.ScheduleDay.TranslateSummary(),
            };

            return dto;
        }
        public static ScheduleSceneSceneDto TranslateScene(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneSceneDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                Scene = scheduleScene.Scene.TranslateSummary(),
                Characters = scheduleScene.Characters.Select(c=> c.TranslateCharacter()),
            };

            return dto;
        }
        public static ScheduleSceneDto Translate(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                ScheduleDayID = scheduleScene.ScheduleDayID,
                SceneID = scheduleScene.SceneID,
            };

            return dto;
        }

        public static ScheduleSceneSummaryDto TranslateSummary(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneSummaryDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                ScheduleDay = scheduleScene.ScheduleDay.TranslateSummary(),
                Scene = scheduleScene.Scene.TranslateSummary(),
            };

            return dto;
        }
        
        public static LinkedScheduleSceneDto TranslateScheduleScene(this ScheduleCharacter scheduleCharacter)
        {
            var dto = new LinkedScheduleSceneDto
            {
                ID = scheduleCharacter.ScheduleScene.ID,
                PageLength = scheduleCharacter.ScheduleScene.PageLength,
                ScheduleDay = scheduleCharacter.ScheduleScene.ScheduleDay.TranslateSummary(),
                Scene = scheduleCharacter.ScheduleScene.Scene.TranslateSummary(),
                LinkID = scheduleCharacter.ID,
            };

            return dto;
        }
    }
}