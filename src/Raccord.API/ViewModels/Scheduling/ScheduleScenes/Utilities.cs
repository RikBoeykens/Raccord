using System.Linq;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullScheduleSceneViewModel Translate(this FullScheduleSceneDto dto)
        {
            return new FullScheduleSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                SceneScheduledPageLength = dto.SceneScheduledPageLength,
                Scene = dto.Scene.Translate(),
                ScheduleDay = dto.ScheduleDay.Translate(),
                Characters = dto.Characters.Select(c=>c.Translate()),
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static ScheduleSceneDayViewModel Translate(this ScheduleSceneDayDto dto)
        {
            return new ScheduleSceneDayViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                ScheduleDay = dto.ScheduleDay.Translate(),
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static ScheduleSceneSceneViewModel Translate(this ScheduleSceneSceneDto dto)
        {
            return new ScheduleSceneSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                Characters = dto.Characters.Select(c=> c.Translate()),
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static ScheduleSceneViewModel Translate(this ScheduleSceneDto dto)
        {
            return new ScheduleSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                ScheduleDayID = dto.ScheduleDayID,
                SceneID = dto.SceneID,
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static ScheduleSceneSummaryViewModel Translate(this ScheduleSceneSummaryDto dto)
        {
            return new ScheduleSceneSummaryViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                ScheduleDay = dto.ScheduleDay.Translate(),
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static LinkedScheduleSceneViewModel Translate(this LinkedScheduleSceneDto dto)
        {
            return new LinkedScheduleSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                ScheduleDay = dto.ScheduleDay.Translate(),
                LinkID = dto.LinkID,
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static ScheduleSceneDto Translate(this ScheduleSceneViewModel vm)
        {
            return new ScheduleSceneDto
            {
                ID = vm.ID,
                PageLength = vm.PageLength,
                ScheduleDayID = vm.ScheduleDayID,
                SceneID = vm.SceneID,
            };
        }
    }
}