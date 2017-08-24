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
                CompletesScene = dto.CompletesScene,
                ShootingDay = dto.ShootingDay.Translate(),
                LocationSet = dto.LocationSet.Translate(),
            };
        }
        public static ShootingDaySceneSceneViewModel Translate(this ShootingDaySceneSceneDto dto)
        {
            return new ShootingDaySceneSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                CompletesScene = dto.CompletesScene,
                ScenePageLength = dto.ScenePageLength,
                SceneTimings = dto.SceneTimings,
                PreviousPageLength = dto.PreviousPageLength,
                PreviousTimings = dto.PreviousTimings,
                Scene = dto.Scene.Translate(),
                LocationSet = dto.LocationSet.Translate(),
            };
        }
        public static ShootingDaySceneViewModel Translate(this ShootingDaySceneDto dto)
        {
            return new ShootingDaySceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                CompletesScene = dto.CompletesScene,
                ShootingDayID = dto.ShootingDayID,
                SceneID = dto.SceneID,
                LocationSetID = dto.LocationSetID,
            };
        }
        public static ShootingDaySceneDto Translate(this ShootingDaySceneViewModel vm)
        {
            return new ShootingDaySceneDto
            {
                ID = vm.ID,
                PageLength = vm.PageLength,
                Timings = vm.Timings,
                CompletesScene = vm.CompletesScene,
                ShootingDayID = vm.ShootingDayID,
                SceneID = vm.SceneID,
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
                CompletesScene = dto.CompletesScene,
            };
        }
    }
}