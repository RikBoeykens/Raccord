using System.Linq;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Services.Scheduling.ScheduleDays;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Locations.LocationSets;

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
                LocationSet = scheduleScene.LocationSetID.HasValue ? scheduleScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
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
                LocationSet = scheduleScene.LocationSetID.HasValue ? scheduleScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
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
                LocationSet = scheduleScene.LocationSetID.HasValue ? scheduleScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
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
                LocationSetID = scheduleScene.LocationSetID,
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
                LocationSet = scheduleScene.LocationSetID.HasValue ? scheduleScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
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
                LocationSet = scheduleCharacter.ScheduleScene.LocationSetID.HasValue ? scheduleCharacter.ScheduleScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
                LinkID = scheduleCharacter.ID,
            };

            return dto;
        }
    }
}