using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Application.Services.ShootingDays.Scenes;
using Raccord.Application.Services.Shots.Slates;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Domain.Model.ShootingDays.Scenes;

namespace Raccord.Application.Services.ShootingDays
{
    public static class Utilities
    {
        public static FullShootingDayDto TranslateFull(this ShootingDay shootingDay, IEnumerable<ShootingDayScene> previousScenes)
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
                //PreviouslyCompletedSceneCount = previousScenes.Count(pcs=> pcs.CompletesScene),
                PreviouslyCompletedScenePageCount = previousScenes.Sum(pcs=> pcs.PageLength),
                PreviouslyCompletedTimingsCount = new TimeSpan(previousScenes.Sum(pcs=> pcs.Timings.Ticks)),
                Scenes = shootingDay.ShootingDayScenes.Select(s=> s.TranslateScene()),
                Slates = shootingDay.Slates.Select(s=> s.TranslateSummary()),
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
                //CompletedScenes = shootingDay.ShootingDayScenes.Count(sds=> sds.CompletesScene),
                TotalPageCount = shootingDay.ShootingDayScenes.Sum(sds=> sds.PageLength),
                TotalTimings = new TimeSpan(shootingDay.ShootingDayScenes.Sum(sds=> sds.Timings.Ticks)),
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
    }
}