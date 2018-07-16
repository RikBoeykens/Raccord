using Raccord.Application.Core.Services.Scenes;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Characters;
using System.Linq;
using Raccord.API.ViewModels.Breakdowns;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.Shots.Slates;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Scenes
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullSceneViewModel Translate(this FullSceneDto dto)
        {
            return new FullSceneViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Summary = dto.Summary,
                PageLength = dto.PageLength,
                Timing = dto.Timing,
                SceneIntro = dto.SceneIntro.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
                TimeOfDay = dto.TimeOfDay.Translate(),
                Images = dto.Images.Select(i=> i.Translate()),
                Characters = dto.Characters.Select(i=> i.Translate()),
                BreakdownInfo = dto.BreakdownInfo.Translate(),
                ShootingDays = dto.ShootingDays.Select(sd=> sd.Translate()),
                Slates = dto.Slates.Select(s=> s.Translate()),
                ProjectID = dto.ProjectID,
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static SceneSummaryViewModel Translate(this SceneSummaryDto dto)
        {
            return new SceneSummaryViewModel
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
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static SceneViewModel Translate(this SceneDto dto)
        {
            return new SceneViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Summary = dto.Summary,
                PageLength = dto.PageLength,
                Timing = dto.Timing,
                SceneIntro = dto.SceneIntro.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
                TimeOfDay = dto.TimeOfDay.Translate(),
                ProjectID = dto.ProjectID,
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static LinkedSceneViewModel Translate(this LinkedSceneDto dto)
        {
            return new LinkedSceneViewModel
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
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static SceneDto Translate(this SceneViewModel vm)
        {
            return new SceneDto
            {
                ID = vm.ID,
                Number = vm.Number,
                Summary = vm.Summary,
                PageLength = vm.PageLength,
                Timing = vm.Timing,
                SceneIntro = vm.SceneIntro.Translate(),
                ScriptLocation = vm.ScriptLocation.Translate(),
                TimeOfDay = vm.TimeOfDay.Translate(),
                ProjectID = vm.ProjectID,
            };
        }

        public static SceneFilterRequestDto Translate(this SceneFilterRequestViewModel vm)
        {
            if(vm == null)
            {
                return null;
            }

            return new SceneFilterRequestDto
            {
                ProjectID = vm.ProjectID,
                SceneIntroIDs = vm.SceneIntroIDs,
                ScriptLocationIDs = vm.ScriptLocationIDs,
                TimeOfDayIDs = vm.TimeOfDayIDs,
                LocationSetIDs = vm.LocationSetIDs,
                LocationIDs = vm.LocationIDs,
                CharacterIDs = vm.CharacterIDs,
                CastMemberIDs = vm.CastMemberIDs,
                BreakdownItemIDs = vm.BreakdownItemIDs,
                ScheduleDayIDs = vm.ScheduleDayIDs,
                ScheduleSceneShootingDayIDs = vm.ScheduleSceneShootingDayIDs,
                CallsheetIDs = vm.CallsheetIDs,
                CallsheetSceneShootingDayIDs = vm.CallsheetSceneShootingDayIDs,
                ShootingDayIDs = vm.ShootingDayIDs,
                SearchText = vm.SearchText,
                MinPageLength = vm.MinPageLength,
                MaxPageLength = vm.MaxPageLength
            };
        }
    }
}