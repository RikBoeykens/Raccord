using System.Linq;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Scheduling.ScheduleScenes;
using System.Collections.Generic;
using Raccord.Domain.Model.Characters;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Domain.Model.Locations.Locations;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Application.Services.ShootingDays;

namespace Raccord.Application.Services.Scheduling.ScheduleDays
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullScheduleDayDto TranslateFull(this ScheduleDay scheduleDay)
        {
            var dto = new FullScheduleDayDto
            {
                ID = scheduleDay.ID,
                Date = scheduleDay.Date,
                Start = scheduleDay.Start,
                End = scheduleDay.End,
                Scenes = scheduleDay.ScheduleScenes.OrderBy(t=> t.SortingOrder)
                                                    .Select(s=> s.TranslateScene()),
                ShootingDay = scheduleDay.ShootingDayID.HasValue ? scheduleDay.ShootingDay.Translate() : new ShootingDayDto(),
                ProjectID = scheduleDay.ProjectID,
            };

            return dto;
        }
        public static ScheduleDaySummaryDto TranslateSummary(this ScheduleDay scheduleDay)
        {
            var dto = new ScheduleDaySummaryDto
            {
                ID = scheduleDay.ID,
                Date = scheduleDay.Date,
                Start = scheduleDay.Start,
                End = scheduleDay.End,
                SceneCount = scheduleDay.ScheduleScenes.Count(),
                PageLength = scheduleDay.ScheduleScenes.Sum(ss=> ss.PageLength),
                ShootingDay = scheduleDay.ShootingDayID.HasValue ? scheduleDay.ShootingDay.Translate() : new ShootingDayDto(),
                ProjectID = scheduleDay.ProjectID,
            };

            return dto;
        }

        public static ScheduleDayDto Translate(this ScheduleDay scheduleDay)
        {
            var dto = new ScheduleDayDto
            {
                ID = scheduleDay.ID,
                Date = scheduleDay.Date,
                Start = scheduleDay.Start,
                End = scheduleDay.End,
                ProjectID = scheduleDay.ProjectID,
            };

            return dto;
        }

        public static IEnumerable<ScheduleDaySceneCollectionDto> GetCharacterScheduleDays(this Character character)
        {
            var scheduleDays = character.CharacterScenes.SelectMany(cs=> cs.ScheduleDays.Select(sd=> sd.ScheduleScene)).GroupBy(sd=> sd.ScheduleDay, sd=> sd, (scheduleDay, scenes)=> new ScheduleDaySceneCollectionDto
            {
                ID = scheduleDay.ID,
                Date = scheduleDay.Date,
                Start = scheduleDay.Start,
                End = scheduleDay.End,
                ProjectID = scheduleDay.ProjectID,
                Scenes = scenes.Select(s=> s.TranslateScene()),
                ShootingDay = scheduleDay.ShootingDayID.HasValue ? scheduleDay.ShootingDay.Translate() : new ShootingDayDto(),
             });

             return scheduleDays;
        }

        public static IEnumerable<ScheduleDaySceneCollectionDto> GetLocationScheduleDays(this Location location)
        {
            var scheduleDays = location.LocationSets.SelectMany(cs=> cs.ScheduleScenes.GroupBy(sd=> sd.ScheduleDay, sd=> sd, (scheduleDay, scenes)=> new ScheduleDaySceneCollectionDto
            {
                ID = scheduleDay.ID,
                Date = scheduleDay.Date,
                Start = scheduleDay.Start,
                End = scheduleDay.End,
                ProjectID = scheduleDay.ProjectID,
                Scenes = scenes.Select(s=> s.TranslateScene()),
                ShootingDay = scheduleDay.ShootingDayID.HasValue ? scheduleDay.ShootingDay.Translate() : new ShootingDayDto(),
             }));

             return scheduleDays;
        }

        public static IEnumerable<ScheduleDaySceneCollectionDto> GetLocationSetScheduleDays(this LocationSet locationSet)
        {
            var scheduleDays = locationSet.ScheduleScenes.GroupBy(sd=> sd.ScheduleDay, sd=> sd, (scheduleDay, scenes)=> new ScheduleDaySceneCollectionDto
            {
                ID = scheduleDay.ID,
                Date = scheduleDay.Date,
                Start = scheduleDay.Start,
                End = scheduleDay.End,
                ProjectID = scheduleDay.ProjectID,
                Scenes = scenes.Select(s=> s.TranslateScene()),
                ShootingDay = scheduleDay.ShootingDayID.HasValue ? scheduleDay.ShootingDay.Translate() : new ShootingDayDto(),
             });

             return scheduleDays;
        }
    }
}