using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;

namespace Raccord.Application.Services.SceneProperties
{
    // Service used for int/ext functionality
    public class SceneIntroService : ISceneIntroService
    {
        private readonly ISceneIntroRepository _sceneIntroRepository;

        // Initialises a new SceneIntroService
        public SceneIntroService(ISceneIntroRepository sceneIntroRepository)
        {
            if(sceneIntroRepository == null)
                throw new ArgumentNullException(nameof(sceneIntroRepository));
            
            _sceneIntroRepository = sceneIntroRepository;
        }

        // Gets all int/exts for a project
        public IEnumerable<SceneIntroSummaryDto> GetAllForParent(long projectID)
        {
            var sceneIntros = _sceneIntroRepository.GetAllForProject(projectID);

            var dtos = sceneIntros.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single int/ext by id
        public FullSceneIntroDto Get(long ID)
        {
            var sceneIntro = _sceneIntroRepository.GetFull(ID);

            var dto = sceneIntro.TranslateFull();

            return dto;
        }

        // Gets a summary of a single int/ext
        public SceneIntroSummaryDto GetSummary(Int64 ID)
        {
            var sceneIntro = _sceneIntroRepository.GetSummary(ID);

            var dto = sceneIntro.TranslateSummary();

            return dto;
        }

        // Adds a int/ext
        public long Add(SceneIntroDto dto)
        {
            var sceneIntro = new SceneIntro
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _sceneIntroRepository.Add(sceneIntro);
            _sceneIntroRepository.Commit();

            return sceneIntro.ID;
        }

        // Updates a int/ext
        public long Update(SceneIntroDto dto)
        {
            var sceneIntro = _sceneIntroRepository.GetSingle(dto.ID);

            sceneIntro.Name = dto.Name;
            sceneIntro.Description = dto.Description;

            _sceneIntroRepository.Edit(sceneIntro);
            _sceneIntroRepository.Commit();

            return sceneIntro.ID;
        }

        // Deletes a int/ext
        public void Delete(Int64 ID)
        {
            var sceneIntro = _sceneIntroRepository.GetSingle(ID);

            _sceneIntroRepository.Delete(sceneIntro);

            _sceneIntroRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toSceneIntro = _sceneIntroRepository.GetFull(toID);
            var mergeSceneIntro = _sceneIntroRepository.GetFull(mergeID);

            var sceneList = toSceneIntro.Scenes.ToList();
            sceneList.AddRange(mergeSceneIntro.Scenes);

            toSceneIntro.Scenes = sceneList;
            mergeSceneIntro.Scenes.Clear();
            _sceneIntroRepository.Edit(toSceneIntro);
            _sceneIntroRepository.Delete(mergeSceneIntro);

            _sceneIntroRepository.Commit();
        }
    }
}