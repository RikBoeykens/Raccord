using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.ShootingDays.Scenes;
using Raccord.Domain.Model.ShootingDays.Scenes;

namespace Raccord.Application.Services.Scheduling.ScheduleScenes
{
    // Service used for schedule scene functionality
    public class ShootingDaySceneService : IShootingDaySceneService
    {
        private readonly IShootingDaySceneRepository _shootingDaySceneRepository;

        // Initialises a new ShootingDaySceneService
        public ShootingDaySceneService(IShootingDaySceneRepository shootingDaySceneRepository
                                    )
        {
            if(shootingDaySceneRepository == null)
                throw new ArgumentNullException(nameof(shootingDaySceneRepository));
            
            _shootingDaySceneRepository = shootingDaySceneRepository;
        }

        // Gets all schedule scenes for a scene
        public IEnumerable<ShootingDaySceneDayDto> GetDays(long sceneID)
        {
            var scheduleScenes = _shootingDaySceneRepository.GetAllForScene(sceneID);

            var dtos = scheduleScenes.Select(l => l.TranslateDay());

            return dtos;
        }

        // Gets all schedule scenes for a day
        public IEnumerable<ShootingDaySceneSceneDto> GetScenes(long dayID)
        {
            var scheduleScenes = _shootingDaySceneRepository.GetAllForShootingDay(dayID);

            var dtos = scheduleScenes.Select(l => l.TranslateScene());

            return dtos;
        }

        // Adds a schedule scene
        public long Add(ShootingDaySceneDto dto)
        {
            var shootingDayScene = new ShootingDayScene
            {
                PageLength = dto.PageLength,
                Timings = dto.Timings,
                CompletesScene = dto.CompletesScene,
                ShootingDayID = dto.ShootingDayID,
                SceneID = dto.SceneID,
                LocationSetID = dto.LocationSetID,
            };

            _shootingDaySceneRepository.Add(shootingDayScene);
            _shootingDaySceneRepository.Commit();

            return shootingDayScene.ID;
        }

        // Updates a schedule scene
        public long Update(ShootingDaySceneDto dto)
        {
            var shootingDayScene = _shootingDaySceneRepository.GetSingle(dto.ID);

            shootingDayScene.PageLength = dto.PageLength;
            shootingDayScene.Timings= dto.Timings;
            shootingDayScene.CompletesScene = dto.CompletesScene;
            shootingDayScene.LocationSetID = dto.LocationSetID;

            _shootingDaySceneRepository.Edit(shootingDayScene);
            _shootingDaySceneRepository.Commit();

            return shootingDayScene.ID;
        }

        // Deletes a schedule scene
        public void Delete(Int64 ID)
        {
            var shootingDayScene = _shootingDaySceneRepository.GetSingle(ID);

            _shootingDaySceneRepository.Delete(shootingDayScene);

            _shootingDaySceneRepository.Commit();
        }
    }
}