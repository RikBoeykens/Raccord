using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Scenes;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Services.Images;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.Locations;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.Locations;
using Raccord.Application.Core.Common.Sorting;
using Raccord.Data.EntityFramework.Repositories.Images;

namespace Raccord.Application.Services.Scenes
{
    // Service used for scene functionality
    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;
        private readonly IIntExtRepository _intExtRepository;
        private readonly IDayNightRepository _dayNightRepository;
        private readonly ILocationRepository _locationRepository;

        // Initialises a new SceneService
        public SceneService(
            ISceneRepository sceneRepository,
            IIntExtRepository intExtRepository,
            IDayNightRepository dayNightRepository,
            ILocationRepository locationRepository
            )
        {
            if(sceneRepository == null)
                throw new ArgumentNullException(nameof(sceneRepository));
            if(intExtRepository == null)
                throw new ArgumentNullException(nameof(intExtRepository));
            if(dayNightRepository == null)
                throw new ArgumentNullException(nameof(dayNightRepository));
            if(locationRepository == null)
                throw new ArgumentNullException(nameof(locationRepository));
            
            _sceneRepository = sceneRepository;
            _intExtRepository = intExtRepository;
            _dayNightRepository = dayNightRepository;
            _locationRepository = locationRepository;
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

            var dto = scene.TranslateFull();

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
            CreatePropertiesIfNecessary(dto);

            var scene = new Scene
            {
                Number = dto.Number,
                Summary = dto.Summary,
                PageLength = dto.PageLength,
                IntExtID = dto.IntExt.ID,
                LocationID = dto.Location.ID,
                DayNightID = dto.DayNight.ID,
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

        private void CreatePropertiesIfNecessary(SceneDto scene)
        {
            if(scene.IntExt.ID == default(long))
            {
                var intExt = new IntExt
                {
                    Name = scene.IntExt.Name,
                    Description = scene.IntExt.Description,
                    ProjectID = scene.IntExt.ProjectID,
                };

                _intExtRepository.Add(intExt);
                _intExtRepository.Commit();

                scene.IntExt.ID = intExt.ID;
            }

            if(scene.DayNight.ID == default(long))
            {
                var dayNight = new DayNight
                {
                    Name = scene.DayNight.Name,
                    Description = scene.DayNight.Description,
                    ProjectID = scene.DayNight.ProjectID,
                };

                _dayNightRepository.Add(dayNight);
                _dayNightRepository.Commit();

                scene.DayNight.ID = dayNight.ID;
            }

            if(scene.Location.ID == default(long))
            {
                var location = new Location
                {
                    Name = scene.Location.Name,
                    Description = scene.Location.Description,
                    ProjectID = scene.Location.ProjectID,
                };

                _locationRepository.Add(location);
                _locationRepository.Commit();

                scene.Location.ID = location.ID;
            }
        }

        private int GetNextSceneOrder(long projectID)
        {
            var scenes = _sceneRepository.GetAllForProject(projectID);
            return scenes.Count();
        }
    }
}