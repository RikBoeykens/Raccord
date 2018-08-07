using System.Linq;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.API.ViewModels.ShootingDays.Scenes;
using Raccord.API.ViewModels.Shots.Slates;
using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.ShootingDays
{
    public static class Utilities
    {
        public static FullShootingDayViewModel Translate(this FullShootingDayDto dto)
        {
            return new FullShootingDayViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                Start = dto.Start,
                Turn = dto.Turn,
                End = dto.End,
                OverTime = dto.OverTime,
                Completed = dto.Completed,
                ScheduleDayID = dto.ScheduleDayID,
                CallsheetID = dto.CallsheetID,
                CrewUnit = dto.CrewUnit.Translate(),
                PreviouslyCompletedSceneCount = dto.PreviouslyCompletedSceneCount,
                PreviouslyCompletedScenePageCount = dto.PreviouslyCompletedScenePageCount,
                PreviouslyCompletedTimingsCount = dto.PreviouslyCompletedTimingsCount,
                PreviousSetupCount = dto.PreviousSetupCount,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Slates = dto.Slates.Select(s=> s.Translate()),
                CameraRolls = dto.CameraRolls,
                SoundRolls = dto.SoundRolls,
            };
        }
        public static ShootingDaySummaryViewModel Translate(this ShootingDaySummaryDto dto)
        {
            return new ShootingDaySummaryViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                Start = dto.Start,
                Turn = dto.Turn,
                End = dto.End,
                OverTime = dto.OverTime,
                Completed = dto.Completed,
                ScheduleDayID = dto.ScheduleDayID,
                CallsheetID = dto.CallsheetID,
                CrewUnitID = dto.CrewUnitID,
                TotalScenes = dto.TotalScenes,
                CompletedScenes = dto.CompletedScenes,
                TotalPageCount = dto.TotalPageCount,
                TotalTimings = dto.TotalTimings,
                TotalSetups = dto.TotalSetups,
            };
        }
        public static ShootingDayCrewUnitViewModel Translate(this ShootingDayCrewUnitDto dto)
        {
            return new ShootingDayCrewUnitViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                Start = dto.Start,
                Turn = dto.Turn,
                End = dto.End,
                OverTime = dto.OverTime,
                Completed = dto.Completed,
                ScheduleDayID = dto.ScheduleDayID,
                CallsheetID = dto.CallsheetID,
                CrewUnit = dto.CrewUnit.Translate(),
            };
        }
        public static ShootingDayViewModel Translate(this ShootingDayDto dto)
        {
            return new ShootingDayViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                Start = dto.Start,
                Turn = dto.Turn,
                End = dto.End,
                OverTime = dto.OverTime,
                Completed = dto.Completed,
                ScheduleDayID = dto.ScheduleDayID,
                CallsheetID = dto.CallsheetID,
                CrewUnitID = dto.CrewUnitID,
            };
        }
        public static ShootingDayDto Translate(this ShootingDayViewModel vm)
        {
            return new ShootingDayDto
            {
                ID = vm.ID,
                Number = vm.Number,
                Date = vm.Date,
                Start = vm.Start,
                Turn = vm.Turn,
                End = vm.End,
                OverTime = vm.OverTime,
                Completed = vm.Completed,
                ScheduleDayID = vm.ScheduleDayID,
                CallsheetID = vm.CallsheetID,
                CrewUnitID = vm.CrewUnitID,
            };
        }
        public static ShootingDayInfoViewModel Translate(this ShootingDayInfoDto dto)
        {
            return new ShootingDayInfoViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                Type = dto.Type,
                CrewUnit = dto.CrewUnit.Translate()
            };
        }
        public static ShootingDayInfoSceneCollectionViewModel Translate(this ShootingDayInfoSceneCollectionDto dto)
        {
            return new ShootingDayInfoSceneCollectionViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                Type = dto.Type,
                CrewUnit = dto.CrewUnit.Translate(),
                Scenes = dto.Scenes.Select(s => s.Translate())
            };
        }
    }
}