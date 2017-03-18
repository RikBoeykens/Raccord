using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Scheduling;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleScenes;
using Raccord.Domain.Model.Images;

namespace Raccord.Application.Services.Scheduling.ScheduleScenes
{
    // Service used for schedule scene functionality
    public class ScheduleSceneService : IScheduleSceneService
    {
        private readonly IScheduleSceneRepository _scheduleSceneRepository;

        // Initialises a new ScheduleSceneService
        public ScheduleSceneService(IScheduleSceneRepository scheduleSceneRepository)
        {
            if(scheduleSceneRepository == null)
                throw new ArgumentNullException(nameof(scheduleSceneRepository));
            
            _scheduleSceneRepository = scheduleSceneRepository;
        }

        // Gets all schedule scenes for a scene
        public IEnumerable<ScheduleSceneDayDto> GetDays(long sceneID)
        {
            var scheduleScenes = _scheduleSceneRepository.GetAllForScene(sceneID);

            var dtos = scheduleScenes.Select(l => l.TranslateDay());

            return dtos;
        }

        // Gets all schedule scenes for a day
        public IEnumerable<ScheduleSceneSceneDto> GetScenes(long dayID)
        {
            var scheduleScenes = _scheduleSceneRepository.GetAllForScheduleDay(dayID);

            var dtos = scheduleScenes.Select(l => l.TranslateScene());

            return dtos;
        }

        // Gets a single schedule scene by id
        public ScheduleSceneDto Get(long ID)
        {
            var scheduleScene = _scheduleSceneRepository.GetSingle(ID);

            var dto = scheduleScene.Translate();

            return dto;
        }

        // Adds a schedule scene
        public long Add(ScheduleSceneDto dto)
        {
            var scheduleScene = new ScheduleScene
            {
                PageLength = dto.PageLength,
                ScheduleDayID = dto.ScheduleDayID,
                SceneID = dto.SceneID
            };

            _scheduleSceneRepository.Add(scheduleScene);
            _scheduleSceneRepository.Commit();

            return scheduleScene.ID;
        }

        // Updates a schedule scene
        public long Update(ScheduleSceneDto dto)
        {
            var scheduleScene = _scheduleSceneRepository.GetSingle(dto.ID);

            scheduleScene.PageLength = dto.PageLength;

            _scheduleSceneRepository.Edit(scheduleScene);
            _scheduleSceneRepository.Commit();

            return scheduleScene.ID;
        }

        // Deletes a schedule scene
        public void Delete(Int64 ID)
        {
            var scheduleScene = _scheduleSceneRepository.GetSingle(ID);

            _scheduleSceneRepository.Delete(scheduleScene);

            _scheduleSceneRepository.Commit();
        }
    }
}