using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;
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
                CallsheetSceneID = dto.CallsheetSceneID
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
                CallsheetSceneID = dto.CallsheetSceneID
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
                CallsheetSceneID = vm.CallsheetSceneID
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
    }
}