using System;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Services.Scenes;
using Raccord.Core.Enums;
using Raccord.Domain.Model.ShootingDays.Scenes;

namespace Raccord.Application.Services.ShootingDays.Scenes
{
    public static class Utilities
    {
        public static ShootingDaySceneSceneDto TranslateScene(this ShootingDayScene shootingDayScene)
        {
            var previousShootingDayScenes = shootingDayScene.Scene.ShootingDayScenes.Where(sds=> sds.ShootingDay.Date < shootingDayScene.ShootingDay.Date);

            return new ShootingDaySceneSceneDto
            {
                ID = shootingDayScene.ID,
                PageLength = shootingDayScene.PageLength,
                Timings = shootingDayScene.Timings,
                Completion = shootingDayScene.Completion,
                ScenePageLength = shootingDayScene.Scene.PageLength,
                SceneTimings = shootingDayScene.Scene.Timing,
                PreviousPageLength = previousShootingDayScenes.Sum(sds=> sds.PageLength),
                PreviousTimings = new TimeSpan(previousShootingDayScenes.Sum(sds=> sds.Timings.Ticks)),
                PlannedPageLength = shootingDayScene.CallsheetSceneID.HasValue ? shootingDayScene.CallsheetScene.PageLength : 0,
                CompletedByOther = shootingDayScene.Scene.ShootingDayScenes.Any(sds=> sds.Completion==Completion.Completed && sds.ID != shootingDayScene.ID),
                Scene = shootingDayScene.Scene.TranslateSummary(),
                CallsheetSceneID = shootingDayScene.CallsheetSceneID,
                LocationSet = shootingDayScene.LocationSet.TranslateLocation(),
                AvailableLocationSets = shootingDayScene.Scene.ScriptLocation.LocationSets.Select(ls=> ls.TranslateLocation()),
            };
        }
        public static ShootingDaySceneDayDto TranslateDay(this ShootingDayScene shootingDayScene)
        {
            return new ShootingDaySceneDayDto
            {
                ID = shootingDayScene.ID,
                PageLength = shootingDayScene.PageLength,
                Timings = shootingDayScene.Timings,
                Completion = shootingDayScene.Completion,
                ShootingDay = shootingDayScene.ShootingDay.Translate(),
                CallsheetSceneID = shootingDayScene.CallsheetSceneID
            };
        }
        public static ShootingDaySceneDto Translate(this ShootingDayScene shootingDayScene)
        {
            return new ShootingDaySceneDto
            {
                ID = shootingDayScene.ID,
                PageLength = shootingDayScene.PageLength,
                Timings = shootingDayScene.Timings,
                Completion = shootingDayScene.Completion,
                ShootingDayID = shootingDayScene.ShootingDayID,
                SceneID = shootingDayScene.SceneID,
                CallsheetSceneID = shootingDayScene.CallsheetSceneID,
                LocationSetID = shootingDayScene.LocationSetID,
            };
        }
    }
}