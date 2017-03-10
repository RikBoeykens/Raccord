using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;

namespace Raccord.Application.Services.SceneProperties
{
    // Service used for int/ext functionality
    public class IntExtService : IIntExtService
    {
        private readonly IIntExtRepository _intExtRepository;

        // Initialises a new IntExtService
        public IntExtService(IIntExtRepository intExtRepository)
        {
            if(intExtRepository == null)
                throw new ArgumentNullException(nameof(intExtRepository));
            
            _intExtRepository = intExtRepository;
        }

        // Gets all int/exts for a project
        public IEnumerable<IntExtSummaryDto> GetAllForParent(long projectID)
        {
            var intExts = _intExtRepository.GetAllForProject(projectID);

            var dtos = intExts.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single int/ext by id
        public FullIntExtDto Get(long ID)
        {
            var intExt = _intExtRepository.GetFull(ID);

            var dto = intExt.TranslateFull();

            return dto;
        }

        // Gets a summary of a single int/ext
        public IntExtSummaryDto GetSummary(Int64 ID)
        {
            var intExt = _intExtRepository.GetSummary(ID);

            var dto = intExt.TranslateSummary();

            return dto;
        }

        // Adds a int/ext
        public long Add(IntExtDto dto)
        {
            var intExt = new IntExt
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _intExtRepository.Add(intExt);
            _intExtRepository.Commit();

            return intExt.ID;
        }

        // Updates a int/ext
        public long Update(IntExtDto dto)
        {
            var intExt = _intExtRepository.GetSingle(dto.ID);

            intExt.Name = dto.Name;
            intExt.Description = dto.Description;

            _intExtRepository.Edit(intExt);
            _intExtRepository.Commit();

            return intExt.ID;
        }

        // Deletes a int/ext
        public void Delete(Int64 ID)
        {
            var intExt = _intExtRepository.GetSingle(ID);

            _intExtRepository.Delete(intExt);

            _intExtRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toIntExt = _intExtRepository.GetFull(toID);
            var mergeIntExt = _intExtRepository.GetFull(mergeID);

            var sceneList = toIntExt.Scenes.ToList();
            sceneList.AddRange(mergeIntExt.Scenes);

            toIntExt.Scenes = sceneList;
            mergeIntExt.Scenes.Clear();
            _intExtRepository.Edit(toIntExt);
            _intExtRepository.Delete(mergeIntExt);

            _intExtRepository.Commit();
        }
    }
}