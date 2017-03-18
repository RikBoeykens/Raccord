using System.Linq;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Scheduling.ScheduleScenes;

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
                Scenes = scheduleDay.ScheduleScenes.OrderBy(s=> s.SortingOrder).Select(s=> s.TranslateScene()),
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
    }
}