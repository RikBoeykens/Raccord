using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Scenes;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Services.Images;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Application.Core.Common.Sorting;
using Raccord.Data.EntityFramework.Repositories.Images;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Core.Utilities;
using Raccord.Application.Core.Common.Paging;
using Raccord.Data.EntityFramework.Repositories.Breakdowns;

namespace Raccord.Application.Services.Scenes
{
    // Service used for scene functionality
    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;
        private readonly ISceneIntroRepository _sceneIntroRepository;
        private readonly ITimeOfDayRepository _timeOfDayRepository;
        private readonly IScriptLocationRepository _scriptLocationRepository;
        private readonly IShootingDayRepository _shootingDayRepository;
        private readonly IBreakdownRepository _breakdownRepository;

        // Initialises a new SceneService
        public SceneService(
            ISceneRepository sceneRepository,
            ISceneIntroRepository sceneIntroRepository,
            ITimeOfDayRepository timeOfDayRepository,
            IScriptLocationRepository scriptLocationRepository,
            IShootingDayRepository shootingDayRepository,
            IBreakdownRepository breakdownRepository
            )
        {
            if(sceneRepository == null)
                throw new ArgumentNullException(nameof(sceneRepository));
            if(sceneIntroRepository == null)
                throw new ArgumentNullException(nameof(sceneIntroRepository));
            if(timeOfDayRepository == null)
                throw new ArgumentNullException(nameof(timeOfDayRepository));
            if(scriptLocationRepository == null)
                throw new ArgumentNullException(nameof(scriptLocationRepository));
            if(shootingDayRepository == null)
                throw new ArgumentNullException(nameof(shootingDayRepository));
            if(breakdownRepository == null)
                throw new ArgumentNullException(nameof(breakdownRepository));
            
            _sceneRepository = sceneRepository;
            _sceneIntroRepository = sceneIntroRepository;
            _timeOfDayRepository = timeOfDayRepository;
            _scriptLocationRepository = scriptLocationRepository;
            _shootingDayRepository = shootingDayRepository;
            _breakdownRepository = breakdownRepository;
        }

        // Gets all scene for a project
        public IEnumerable<SceneSummaryDto> GetAllForParent(long projectID)
        {
            var scenes = _sceneRepository.GetAllForProject(projectID);

            var dtos = scenes.Select(l => l.TranslateSummary()).ToList();

            return dtos;
        }

        // Gets a single scene by id
        public FullSceneDto Get(Int64 ID, string userID)
        {
            var scene = _sceneRepository.GetFull(ID);
            var shootingDays = _shootingDayRepository.GetAllForScene(ID);
            var breakdown = _breakdownRepository.GetForProjectUser(scene.ProjectID, userID);

            var dto = scene.TranslateFull(shootingDays, breakdown);

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
        public long Add(SceneDto dto)
        {
            return AddScene(dto);
        }

        public long AddByScriptUpload(SceneDto dto, long scriptUploadID)
        {
            return AddScene(dto, scriptUploadID);
        }

        // Adds a scene
        private long AddScene(SceneDto dto, long? scriptUploadID = null)
        {
            CreatePropertiesIfNecessary(dto, scriptUploadID);

            var scene = new Scene
            {
                Number = dto.Number,
                Summary = dto.Summary,
                PageLength = dto.PageLength,
                Timing = dto.Timing,
                SceneIntroID = dto.SceneIntro.ID.GetValueOrNull(),
                ScriptLocationID = dto.ScriptLocation.ID.GetValueOrNull(),
                TimeOfDayID = dto.TimeOfDay.ID.GetValueOrNull(),
                ScriptUploadID = scriptUploadID,
                ProjectID = dto.ProjectID,
                SortingOrder = (int?)null,
            };

            _sceneRepository.Add(scene);
            _sceneRepository.Commit();

            return scene.ID;
        }

        // Updates a scene
        public long Update(SceneDto dto)
        {
            CreatePropertiesIfNecessary(dto);

            var scene = _sceneRepository.GetSingle(dto.ID);

            scene.Number = dto.Number;
            scene.Summary = dto.Summary;
            scene.PageLength = dto.PageLength;
            scene.Timing = dto.Timing;
            scene.SceneIntroID = dto.SceneIntro.ID.GetValueOrNull();
            scene.ScriptLocationID = dto.ScriptLocation.ID.GetValueOrNull();
            scene.TimeOfDayID = dto.TimeOfDay.ID.GetValueOrNull();

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

        // Sorts scenes
        public void Sort(SortOrderDto order)
        {
            var scenes = _sceneRepository.GetAllForProject(order.ParentID);

            foreach(var scene in scenes)
            {
                var orderedIndex = Array.IndexOf(order.SortIDs, scene.ID);
                scene.SortingOrder = orderedIndex != -1 ? orderedIndex : (int?)null;
                _sceneRepository.Edit(scene);
            }

            _sceneRepository.Commit();
        }

        public PagedDataDto<SceneSummaryDto> Filter(SceneFilterRequestDto filter, PaginationRequestDto requestDto)
        {
            var scenes = _sceneRepository.Filter(
                projectID: filter.ProjectID,
                sceneIntroIDs: filter.SceneIntroIDs,
                scriptLocationIDs: filter.ScriptLocationIDs,
                timeOfDayIDs: filter.TimeOfDayIDs,
                locationSetIDs: filter.LocationSetIDs,
                locationIDs: filter.LocationIDs,
                characterIDs: filter.CharacterIDs,
                castMemberIDs: filter.CastMemberIDs,
                breakdownItemIDs: filter.BreakdownItemIDs,
                scheduleDayIDs: filter.ScheduleDayIDs,
                scheduleSceneShootingDayIDs: filter.ScheduleSceneShootingDayIDs,
                callsheetIDs: filter.CallsheetIDs,
                callsheetSceneShootingDayIDs: filter.CallsheetSceneShootingDayIDs,
                shootingDayIDs: filter.ShootingDayIDs,
                searchText: filter.SearchText,
                minPageLength: filter.MinPageLength,
                maxPageLength: filter.MaxPageLength
            );
            return scenes.GetPaged<Scene, SceneSummaryDto>(requestDto, Utilities.TranslateSummary);
        }

        private void CreatePropertiesIfNecessary(SceneDto scene, long? scriptUploadID = null)
        {
            if(scene.SceneIntro.ID == default(long) && !string.IsNullOrEmpty(scene.SceneIntro.Name))
            {
                var existingSceneIntro = _sceneIntroRepository.FindBy(i=> i.Name.ToLower() == scene.SceneIntro.Name.ToLower()&& i.ProjectID == scene.ProjectID);
                if(existingSceneIntro.Any())
                {
                    scene.SceneIntro.ID = existingSceneIntro.FirstOrDefault().ID;
                }
                else
                {
                    var sceneIntro = new SceneIntro
                    {
                        Name = scene.SceneIntro.Name,
                        Description = scene.SceneIntro.Description,
                        ScriptUploadID = scriptUploadID,
                        ProjectID = scene.SceneIntro.ProjectID,
                    };

                    _sceneIntroRepository.Add(sceneIntro);
                    _sceneIntroRepository.Commit();

                    scene.SceneIntro.ID = sceneIntro.ID;
                }
            }

            if(scene.TimeOfDay.ID == default(long) && !string.IsNullOrEmpty(scene.TimeOfDay.Name))
            {
                var existingTimeOfDay = _timeOfDayRepository.FindBy(i=> i.Name.ToLower() == scene.TimeOfDay.Name.ToLower()&& i.ProjectID == scene.ProjectID);

                if(existingTimeOfDay.Any())
                {
                    scene.TimeOfDay.ID = existingTimeOfDay.FirstOrDefault().ID;
                }
                else
                {
                    var timeOfDay = new TimeOfDay
                    {
                        Name = scene.TimeOfDay.Name,
                        Description = scene.TimeOfDay.Description,
                        ScriptUploadID = scriptUploadID,
                        ProjectID = scene.TimeOfDay.ProjectID,
                    };

                    _timeOfDayRepository.Add(timeOfDay);
                    _timeOfDayRepository.Commit();

                    scene.TimeOfDay.ID = timeOfDay.ID;
                }
            }

            if(scene.ScriptLocation.ID == default(long) && !string.IsNullOrEmpty(scene.ScriptLocation.Name))
            {
                var existingScriptLocation = _scriptLocationRepository.FindBy(i=> i.Name.ToLower() == scene.ScriptLocation.Name.ToLower()&& i.ProjectID == scene.ProjectID);

                if(existingScriptLocation.Any())
                {
                    scene.ScriptLocation.ID = existingScriptLocation.FirstOrDefault().ID;
                }
                else
                {
                    var scriptLocation = new ScriptLocation
                    {
                        Name = scene.ScriptLocation.Name,
                        Description = scene.ScriptLocation.Description,
                        ScriptUploadID = scriptUploadID,
                        ProjectID = scene.ScriptLocation.ProjectID,
                    };

                    _scriptLocationRepository.Add(scriptLocation);
                    _scriptLocationRepository.Commit();

                    scene.ScriptLocation.ID = scriptLocation.ID;
                }
            }
        }
    }
}