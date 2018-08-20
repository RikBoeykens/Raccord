using System.Linq;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.Application.Core.Services.ShootingDays.Scenes;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    public static class Utilities
    {
        public static ShootingDaySceneDayViewModel Translate(this ShootingDaySceneDayDto dto)
        {
            return new ShootingDaySceneDayViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                Completion = dto.Completion,
                ShootingDay = dto.ShootingDay.Translate(),
                CallsheetSceneID = dto.CallsheetSceneID
            };
        }
        public static ShootingDaySceneSceneViewModel Translate(this ShootingDaySceneSceneDto dto)
        {
            return new ShootingDaySceneSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                Completion = dto.Completion,
                ScenePageLength = dto.ScenePageLength,
                SceneTimings = dto.SceneTimings,
                PreviousPageLength = dto.PreviousPageLength,
                PreviousTimings = dto.PreviousTimings,
                PlannedPageLength = dto.PlannedPageLength,
                CompletedByOther = dto.CompletedByOther,
                Scene = dto.Scene.Translate(),
                CallsheetSceneID = dto.CallsheetSceneID,
                LocationSet = dto.LocationSet.Translate(),
                AvailableLocationSets = dto.AvailableLocationSets.Select(als=> als.Translate())
            };
        }
        public static ShootingDaySceneViewModel Translate(this ShootingDaySceneDto dto)
        {
            return new ShootingDaySceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                Completion = dto.Completion,
                ShootingDayID = dto.ShootingDayID,
                SceneID = dto.SceneID,
                CallsheetSceneID = dto.CallsheetSceneID,
                LocationSetID = dto.LocationSetID
            };
        }
        public static ShootingDaySceneDto Translate(this ShootingDaySceneViewModel vm)
        {
            return new ShootingDaySceneDto
            {
                ID = vm.ID,
                PageLength = vm.PageLength,
                Timings = vm.Timings,
                Completion = vm.Completion,
                ShootingDayID = vm.ShootingDayID,
                SceneID = vm.SceneID,
                CallsheetSceneID = vm.CallsheetSceneID,
                LocationSetID = vm.LocationSetID,
            };
        }
        public static BaseShootingDaySceneViewModel Translate(this BaseShootingDaySceneDto dto)
        {
            return new BaseShootingDaySceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                Completion = dto.Completion,
                CallsheetSceneID = dto.CallsheetSceneID
            };
        }
        public static ShootingDaySceneSummaryViewModel Translate(this ShootingDaySceneSummaryDto dto)
        {
            return new ShootingDaySceneSummaryViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Summary = dto.Summary,
                PageLength = dto.PageLength,
                Timing = dto.Timing,
                SceneIntro = dto.SceneIntro.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
                TimeOfDay = dto.TimeOfDay.Translate(),
                PrimaryImage = dto.PrimaryImage.Translate(),
                ProjectID = dto.ProjectID,
                LinkID = dto.LinkID,
                ScheduledPageLength = dto.ScheduledPageLength
            };
        }
    }
}