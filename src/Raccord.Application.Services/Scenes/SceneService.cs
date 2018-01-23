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

namespace Raccord.Application.Services.Scenes
{
    // Service used for scene functionality
    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;
        private readonly IIntExtRepository _intExtRepository;
        private readonly IDayNightRepository _dayNightRepository;
        private readonly IScriptLocationRepository _scriptLocationRepository;
        private readonly IShootingDayRepository _shootingDayRepository;

        // Initialises a new SceneService
        public SceneService(
            ISceneRepository sceneRepository,
            IIntExtRepository intExtRepository,
            IDayNightRepository dayNightRepository,
            IScriptLocationRepository scriptLocationRepository,
            IShootingDayRepository shootingDayRepository
            )
        {
            if(sceneRepository == null)
                throw new ArgumentNullException(nameof(sceneRepository));
            if(intExtRepository == null)
                throw new ArgumentNullException(nameof(intExtRepository));
            if(dayNightRepository == null)
                throw new ArgumentNullException(nameof(dayNightRepository));
            if(scriptLocationRepository == null)
                throw new ArgumentNullException(nameof(scriptLocationRepository));
            if(shootingDayRepository == null)
                throw new ArgumentNullException(nameof(shootingDayRepository));
            
            _sceneRepository = sceneRepository;
            _intExtRepository = intExtRepository;
            _dayNightRepository = dayNightRepository;
            _scriptLocationRepository = scriptLocationRepository;
            _shootingDayRepository = shootingDayRepository;
        }

        // Gets all scene for a project
        public IEnumerable<SceneSummaryDto> GetAllForParent(long projectID)
        {
            var scenes = _sceneRepository.GetAllForProject(projectID);

            var dtos = scenes.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single scene by id
        public FullSceneDto Get(Int64 ID)
        {
            var scene = _sceneRepository.GetFull(ID);
            var shootingDays = _shootingDayRepository.GetAllForScene(ID);

            var dto = scene.TranslateFull(shootingDays);

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
                IntExtID = dto.IntExt.ID.GetValueOrNull(),
                ScriptLocationID = dto.ScriptLocation.ID.GetValueOrNull(),
                DayNightID = dto.DayNight.ID.GetValueOrNull(),
                ScriptUploadID = scriptUploadID,
                ProjectID = dto.ProjectID,
                SortingOrder = GetNextSceneOrder(dto.ProjectID),
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
            scene.IntExtID = dto.IntExt.ID.GetValueOrNull();
            scene.ScriptLocationID = dto.ScriptLocation.ID.GetValueOrNull();
            scene.DayNightID = dto.DayNight.ID.GetValueOrNull();

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
                scene.SortingOrder = orderedIndex != -1 ? orderedIndex : scenes.Count();
                _sceneRepository.Edit(scene);
            }

            _sceneRepository.Commit();
        }

        public IEnumerable<SceneSummaryDto> Filter(SceneFilterRequestDto filter)
        {
            var scenes = _sceneRepository.Filter(
                filter.ProjectID,
                filter.IntExtIDs,
                filter.ScriptLocationIDs,
                filter.DayNightIDs,
                filter.LocationSetIDs,
                filter.LocationIDs,
                filter.CharacterIDs,
                filter.BreakdownItemIDs,
                filter.ScheduleDayIDs,
                filter.ScheduleSceneShootingDayIDs,
                filter.CallsheetIDs,
                filter.CallsheetSceneShootingDayIDs,
                filter.ShootingDayIDs,
                filter.SearchText,
                filter.MinPageLength,
                filter.MaxPageLength
            );

            return scenes.Select(s => s.TranslateSummary()).ToList();
        }

        private void CreatePropertiesIfNecessary(SceneDto scene, long? scriptUploadID = null)
        {
            if(scene.IntExt.ID == default(long) && !string.IsNullOrEmpty(scene.IntExt.Name))
            {
                var existingIntExt = _intExtRepository.FindBy(i=> i.Name.ToLower() == scene.IntExt.Name.ToLower()&& i.ProjectID == scene.ProjectID);
                if(existingIntExt.Any())
                {
                    scene.IntExt.ID = existingIntExt.FirstOrDefault().ID;
                }
                else
                {
                    var intExt = new IntExt
                    {
                        Name = scene.IntExt.Name,
                        Description = scene.IntExt.Description,
                        ScriptUploadID = scriptUploadID,
                        ProjectID = scene.IntExt.ProjectID,
                    };

                    _intExtRepository.Add(intExt);
                    _intExtRepository.Commit();

                    scene.IntExt.ID = intExt.ID;
                }
            }

            if(scene.DayNight.ID == default(long) && !string.IsNullOrEmpty(scene.DayNight.Name))
            {
                var existingDayNight = _dayNightRepository.FindBy(i=> i.Name.ToLower() == scene.DayNight.Name.ToLower()&& i.ProjectID == scene.ProjectID);

                if(existingDayNight.Any())
                {
                    scene.DayNight.ID = existingDayNight.FirstOrDefault().ID;
                }
                else
                {
                    var dayNight = new DayNight
                    {
                        Name = scene.DayNight.Name,
                        Description = scene.DayNight.Description,
                        ScriptUploadID = scriptUploadID,
                        ProjectID = scene.DayNight.ProjectID,
                    };

                    _dayNightRepository.Add(dayNight);
                    _dayNightRepository.Commit();

                    scene.DayNight.ID = dayNight.ID;
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

        private int GetNextSceneOrder(long projectID)
        {
            var scenes = _sceneRepository.GetAllForProject(projectID);
            return scenes.Count();
        }
    }
}