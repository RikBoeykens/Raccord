using System;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Services.Scenes;
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
                CompletesScene = shootingDayScene.CompletesScene,
                ScenePageLength = shootingDayScene.Scene.PageLength,
                SceneTimings = shootingDayScene.Scene.Timing,
                PreviousPageLength = previousShootingDayScenes.Sum(sds=> sds.PageLength),
                PreviousTimings = new TimeSpan(previousShootingDayScenes.Sum(sds=> sds.Timings.Ticks)),
                Scene = shootingDayScene.Scene.TranslateSummary(),
                LocationSet = shootingDayScene.LocationSet.TranslateSummary(),
            };
        }
        public static ShootingDaySceneDayDto TranslateDay(this ShootingDayScene shootingDayScene)
        {
            return new ShootingDaySceneDayDto
            {
                ID = shootingDayScene.ID,
                PageLength = shootingDayScene.PageLength,
                Timings = shootingDayScene.Timings,
                CompletesScene = shootingDayScene.CompletesScene,
                ShootingDay = shootingDayScene.ShootingDay.Translate(),
                LocationSet = shootingDayScene.LocationSet.TranslateSummary(),
            };
        }
        public static ShootingDaySceneDto Translate(this ShootingDayScene shootingDayScene)
        {
            return new ShootingDaySceneDto
            {
                ID = shootingDayScene.ID,
                PageLength = shootingDayScene.PageLength,
                Timings = shootingDayScene.Timings,
                CompletesScene = shootingDayScene.CompletesScene,
                ShootingDayID = shootingDayScene.ShootingDayID,
                SceneID = shootingDayScene.SceneID,
                LocationSetID = shootingDayScene.LocationSetID,
            };
        }
    }
}