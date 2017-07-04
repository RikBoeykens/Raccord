using System.Linq;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullScheduleDayViewModel Translate(this FullScheduleDayDto dto)
        {
            return new FullScheduleDayViewModel
            {
                ID = dto.ID,
                Date = dto.Date,
                Start = dto.Start,
                End = dto.End,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Notes = dto.Notes.Select(n=> n.Translate()),
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static ScheduleDaySummaryViewModel Translate(this ScheduleDaySummaryDto dto)
        {
            return new ScheduleDaySummaryViewModel
            {
                ID = dto.ID,
                Date = dto.Date,
                Start = dto.Start,
                End = dto.End,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
                PageLength = dto.PageLength,
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static ScheduleDayViewModel Translate(this ScheduleDayDto dto)
        {
            return new ScheduleDayViewModel
            {
                ID = dto.ID,
                Date = dto.Date,
                Start = dto.Start,
                End = dto.End,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static ScheduleDaySceneCollectionViewModel Translate(this ScheduleDaySceneCollectionDto dto)
        {
            return new ScheduleDaySceneCollectionViewModel
            {
                ID = dto.ID,
                Date = dto.Date,
                Start = dto.Start,
                End = dto.End,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static ScheduleDayDto Translate(this ScheduleDayViewModel vm)
        {
            return new ScheduleDayDto
            {
                ID = vm.ID,
                Date = vm.Date,
                Start = vm.Start,
                End = vm.End,
                ProjectID = vm.ProjectID,
            };
        }
    }
}