using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Raccord.Application.Services.Crew.CrewUnits;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.ShootingDays.Scenes;
using Raccord.Application.Services.Shots.Slates;
using Raccord.Core.Enums;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Domain.Model.ShootingDays.Scenes;

namespace Raccord.Application.Services.ShootingDays
{
    public static class Utilities
    {
        public static FullShootingDayDto TranslateFull(this ShootingDay shootingDay, IEnumerable<ShootingDay> previousDays)
        {
            return new FullShootingDayDto
            {
                ID = shootingDay.ID,
                Number = shootingDay.Number,
                Date = shootingDay.Date,
                Start = shootingDay.Start,
                Turn = shootingDay.Turn,
                End = shootingDay.End,
                OverTime = shootingDay.OverTime,
                Completed = shootingDay.Completed,
                ScheduleDayID = shootingDay.ScheduleDayID,
                CallsheetID = shootingDay.CallsheetID,
                CrewUnit = shootingDay.CrewUnit.Translate(),
                PreviouslyCompletedSceneCount = previousDays.SelectMany(sd=> sd.ShootingDayScenes).Count(pcs=> pcs.Completion == Completion.Completed),
                PreviouslyCompletedScenePageCount = previousDays.SelectMany(sd=> sd.ShootingDayScenes).Sum(pcs=> pcs.PageLength),
                PreviouslyCompletedTimingsCount = new TimeSpan(previousDays.SelectMany(sd=> sd.ShootingDayScenes).Sum(pcs=> pcs.Timings.Ticks)),
                Scenes = shootingDay.ShootingDayScenes.Select(s=> s.TranslateScene()),
                PreviousSetupCount = previousDays.Sum(sd=> sd.Slates.Count()),
                Slates = shootingDay.Slates.OrderBy(t=> t.SortingOrder)
                                           .Select(s=> s.TranslateSummary()),
                CameraRolls = shootingDay.Slates.SelectMany(s=> s.Takes.Select(t=> t.CameraRoll)).Distinct(),
                SoundRolls = shootingDay.Slates.SelectMany(s=> s.Takes.Select(t=> t.SoundRoll)).Distinct(),
            };
        }
        public static ShootingDaySummaryDto TranslateSummary(this ShootingDay shootingDay)
        {
            return new ShootingDaySummaryDto
            {
                ID = shootingDay.ID,
                Number = shootingDay.Number,
                Date = shootingDay.Date,
                Start = shootingDay.Start,
                Turn = shootingDay.Turn,
                End = shootingDay.End,
                OverTime = shootingDay.OverTime,
                Completed = shootingDay.Completed,
                ScheduleDayID = shootingDay.ScheduleDayID,
                CallsheetID = shootingDay.CallsheetID,
                CrewUnitID = shootingDay.CrewUnitID,
                TotalScenes = shootingDay.ShootingDayScenes.Count,
                CompletedScenes = shootingDay.ShootingDayScenes.Count(sds=> sds.Completion == Completion.Completed),
                TotalPageCount = shootingDay.ShootingDayScenes.Sum(sds=> sds.PageLength),
                TotalTimings = new TimeSpan(shootingDay.ShootingDayScenes.Sum(sds=> sds.Timings.Ticks)),
                TotalSetups = shootingDay.Slates.Count(),
            };
        }
        public static ShootingDayDto Translate(this ShootingDay shootingDay)
        {
            return new ShootingDayDto
            {
                ID = shootingDay.ID,
                Number = shootingDay.Number,
                Date = shootingDay.Date,
                Start = shootingDay.Start,
                Turn = shootingDay.Turn,
                End = shootingDay.End,
                OverTime = shootingDay.OverTime,
                Completed = shootingDay.Completed,
                ScheduleDayID = shootingDay.ScheduleDayID,
                CallsheetID = shootingDay.CallsheetID,
                CrewUnitID = shootingDay.CrewUnitID
            };
        }
        public static ShootingDayCrewUnitDto TranslateCrewUnit(this ShootingDay shootingDay)
        {
            return new ShootingDayCrewUnitDto
            {
                ID = shootingDay.ID,
                Number = shootingDay.Number,
                Date = shootingDay.Date,
                Start = shootingDay.Start,
                Turn = shootingDay.Turn,
                End = shootingDay.End,
                OverTime = shootingDay.OverTime,
                Completed = shootingDay.Completed,
                ScheduleDayID = shootingDay.ScheduleDayID,
                CallsheetID = shootingDay.CallsheetID,
                CrewUnit = shootingDay.CrewUnit.Translate()
            };
        }

        public static ShootingDayInfoDto TranslateSceneInfo(this ShootingDay shootingDay, long sceneID)
        {
            var dto = new ShootingDayInfoDto
            {
                Number = shootingDay.Number,
                Date = shootingDay.Date,
                CrewUnit = shootingDay.CrewUnit.Translate(),
            };

            if(shootingDay.Completed && shootingDay.ShootingDayScenes.Where(sds=> sds.SceneID == sceneID).Any(sds=> sds.Completion == Completion.Completed || sds.Completion == Completion.PartCompleted))
            {
                dto.ID = shootingDay.ID;
                dto.Type = ShootingDayType.Shot;
            } else if (shootingDay.Completed){
                dto.ID = shootingDay.CallsheetID.Value;
                dto.Type = ShootingDayType.CallsheetNotShot;
            } else if (shootingDay.CallsheetID.HasValue && shootingDay.Callsheet.CallsheetScenes.Any(css=> css.SceneID == sceneID)){
                dto.ID = shootingDay.CallsheetID.Value;
                dto.Type = ShootingDayType.Callsheet;
            } else if (shootingDay.CallsheetID.HasValue)
            {
                dto.ID = shootingDay.ScheduleDayID.Value;
                dto.Type = ShootingDayType.ScheduledNotOnCallsheet;
            } else
            {
                dto.ID = shootingDay.ScheduleDayID.Value;
                dto.Type = ShootingDayType.Scheduled;
            }

            return dto;
        }

        public static IEnumerable<ShootingDayInfoSceneCollectionDto> GetCharacterShootingDays(this IEnumerable<ShootingDay> shootingDays, long[] characterIds)
        {
            var callsheetShootingDays = shootingDays.Where(sd => characterIds.Any(cId => sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs => cs.Characters.Any(csc => csc.CharacterScene.CharacterID == cId)))).ToList();

            var callsheetDtos = callsheetShootingDays.Select(sd => new ShootingDayInfoSceneCollectionDto
            {
                ID = sd.CallsheetID.Value,
                Number = sd.Number,
                Date = sd.Date,
                CrewUnit = sd.CrewUnit.Translate(),
                Type = ShootingDayType.Callsheet,
                Scenes = sd.Callsheet.CallsheetScenes.Where(cs => characterIds.Any(cId => cs.Characters.Any(csc => csc.CharacterScene.CharacterID == cId)))
                    .Select(cs => cs.TranslateSummary())
            });
            var scheduleShootingDays = shootingDays.Where(sd => characterIds.Any(cId => sd.ScheduleDayID.HasValue && !sd.CallsheetID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(cs => cs.Characters.Any(csc => csc.CharacterScene.CharacterID == cId)))).ToList();

            var scheduleDtos = scheduleShootingDays.Select(sd => new ShootingDayInfoSceneCollectionDto
            {
                ID = sd.ScheduleDayID.Value,
                Number = sd.Number,
                Date = sd.Date,
                CrewUnit = sd.CrewUnit.Translate(),
                Type = ShootingDayType.Scheduled,
                Scenes = sd.ScheduleDay.ScheduleScenes.Where(cs => characterIds.Any(cId => cs.Characters.Any(csc => csc.CharacterScene.CharacterID == cId)))
                    .Select(cs => cs.TranslateSummary())
            });
            return callsheetDtos.Concat(scheduleDtos);
        }

        public static IEnumerable<ShootingDayInfoSceneCollectionDto> GetLocationSetShootingDays(this IEnumerable<ShootingDay> shootingDays, long[] locationSetIds)
        {
            var callsheetShootingDays =  shootingDays.Where(sd => locationSetIds.Any(lId => sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs => cs.LocationSetID == lId))).ToList();

            var callsheetDtos = callsheetShootingDays.Select(sd => new ShootingDayInfoSceneCollectionDto
            {
                ID = sd.CallsheetID.Value,
                Number = sd.Number,
                Date = sd.Date,
                CrewUnit = sd.CrewUnit.Translate(),
                Type = ShootingDayType.Callsheet,
                Scenes = sd.Callsheet.CallsheetScenes.Where(cs => locationSetIds.Any(lId => cs.LocationSetID == lId))
                    .Select(cs => cs.TranslateSummary())
            });
            var scheduleShootingDays =  shootingDays.Where(sd => locationSetIds.Any(lId => sd.ScheduleDayID.HasValue && !sd.CallsheetID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(cs => cs.LocationSetID == lId))).ToList();

            var scheduleDtos = scheduleShootingDays.Select(sd => new ShootingDayInfoSceneCollectionDto
            {
                ID = sd.ScheduleDayID.Value,
                Number = sd.Number,
                Date = sd.Date,
                CrewUnit = sd.CrewUnit.Translate(),
                Type = ShootingDayType.Scheduled,
                Scenes = sd.ScheduleDay.ScheduleScenes.Where(cs => locationSetIds.Any(lId => cs.LocationSetID == lId))
                    .Select(cs => cs.TranslateSummary())
            });
            return callsheetDtos.Concat(scheduleDtos);
        }

        public static IEnumerable<ShootingDayInfoSceneCollectionDto> GetBreakdownItemShootingDays(this IEnumerable<ShootingDay> shootingDays, long breakdownItemId)
        {
            var callsheetShootingDays = shootingDays.Where(sd => sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs => cs.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemId))).ToList();

            var callsheetDtos = callsheetShootingDays.Select(sd => new ShootingDayInfoSceneCollectionDto
            {
                ID = sd.CallsheetID.Value,
                Number = sd.Number,
                Date = sd.Date,
                CrewUnit = sd.CrewUnit.Translate(),
                Type = ShootingDayType.Callsheet,
                Scenes = sd.Callsheet.CallsheetScenes.Where(cs => cs.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemId))
                    .Select(cs => cs.TranslateSummary())
            });
            var scheduleShootingDays = shootingDays.Where(sd => sd.ScheduleDayID.HasValue && !sd.CallsheetID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(cs => cs.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemId))).ToList();

            var scheduleDtos = scheduleShootingDays.Select(sd => new ShootingDayInfoSceneCollectionDto
            {
                ID = sd.ScheduleDayID.Value,
                Number = sd.Number,
                Date = sd.Date,
                CrewUnit = sd.CrewUnit.Translate(),
                Type = ShootingDayType.Scheduled,
                Scenes = sd.ScheduleDay.ScheduleScenes.Where(cs => cs.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemId))
                    .Select(cs => cs.TranslateSummary())
            });
            return callsheetDtos.Concat(scheduleDtos);
        }
    }
}