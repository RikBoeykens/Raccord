using System.Linq;
using Raccord.Application.Core.Services.Locations;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Services.Scheduling.ScheduleScenes
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static ScheduleSceneDayDto TranslateDay(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneDayDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                ScheduleDay = scheduleScene.ScheduleDay.TranslateSummary(),
            };

            return dto;
        }
        public static ScheduleSceneSceneDto TranslateScene(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneSceneDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                Scene = scheduleScene.Scene.TranslateSummary(),
            };

            return dto;
        }
        public static ScheduleSceneDto Translate(this ScheduleScene scheduleScene)
        {
            var dto = new ScheduleSceneDto
            {
                ID = scheduleScene.ID,
                PageLength = scheduleScene.PageLength,
                ScheduleDayID = scheduleScene.ScheduleDayID,
                SceneID = scheduleScene.SceneID,
            };

            return dto;
        }
    }
}