using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Scenes;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Data.EntityFramework.Repositories.Scenes;

namespace Raccord.Application.Services.Scenes
{
    // Service used for scene functionality
    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;

        // Initialises a new SceneService
        public SceneService(ISceneRepository sceneRepository)
        {
            if(sceneRepository == null)
                throw new ArgumentNullException(nameof(sceneRepository));
            
            _sceneRepository = sceneRepository;
        }

        // Gets all scene for a project
        public IEnumerable<SceneSummaryDto> GetAllForProject(long projectID)
        {
            var scenes = _sceneRepository.GetAllForProject(projectID);

            var dtos = scenes.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single scene by id
        public SceneDto Get(Int64 ID)
        {
            var scene = _sceneRepository.GetFull(ID);

            var dto = scene.Translate();

            return dto;
        }

        // Gets a summary of a single scene
        public SceneSummaryDto GetSummary(Int64 ID)
        {
            var scene = _sceneRepository.GetSummary(ID);

            var dto = scene.TranslateSummary();

            return dto;
        }

        // Adds a scene
        public long Add(SceneSummaryDto dto)
        {
            var scene = new Scene
            {
                Number = dto.Number,
                Summary = dto.Summary,
                PageLength = dto.PageLength,
                IntExtID = dto.IntExt.ID,
                LocationID = dto.Location.ID,
                DayNightID = dto.DayNight.ID,
                ProjectID = dto.ProjectID
            };

            _sceneRepository.Add(scene);
            _sceneRepository.Commit();

            return scene.ID;
        }

        // Updates a scene
        public long Update(SceneSummaryDto dto)
        {
            var scene = _sceneRepository.GetSingle(dto.ID);

            scene.Number = dto.Number;
            scene.Summary = dto.Summary;
            scene.PageLength = dto.PageLength;
            scene.IntExtID = dto.IntExt.ID;
            scene.LocationID = dto.Location.ID;
            scene.DayNightID = dto.DayNight.ID;

            _sceneRepository.Edit(scene);
            _sceneRepository.Commit();

            return scene.ID;
        }

        // Deletes a scene
        public void Delete(long ID)
        {
            var scene = _sceneRepository.GetSingle(ID);

            _sceneRepository.Delete(scene);

            _sceneRepository.Commit();
        }
    }
}