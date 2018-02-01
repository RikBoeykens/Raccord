using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays;
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
                ProjectID = shootingDay.ProjectID,
                PreviouslyCompletedSceneCount = previousDays.SelectMany(sd=> sd.ShootingDayScenes).Count(pcs=> pcs.Completion == Completion.Completed),
                PreviouslyCompletedScenePageCount = previousDays.SelectMany(sd=> sd.ShootingDayScenes).Sum(pcs=> pcs.PageLength),
                PreviouslyCompletedTimingsCount = new TimeSpan(previousDays.SelectMany(sd=> sd.ShootingDayScenes).Sum(pcs=> pcs.Timings.Ticks)),
                Scenes = shootingDay.ShootingDayScenes.Select(s=> s.TranslateScene()),
                PreviousSetupCount = previousDays.Sum(sd=> sd.Slates.Count()),
                Slates = shootingDay.Slates.OrderBy(t=> t.SortingOrder.HasValue)
                                           .ThenBy(t => t.SortingOrder)
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
                ProjectID = shootingDay.ProjectID,
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
                ProjectID = shootingDay.ProjectID
            };
        }

        public static ShootingDayInfoDto TranslateSceneInfo(this ShootingDay shootingDay, long sceneID)
        {
            var dto = new ShootingDayInfoDto
            {
                Number = shootingDay.Number,
                Date = shootingDay.Date
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
    }
}