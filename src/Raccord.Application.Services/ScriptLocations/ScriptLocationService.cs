using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Domain.Model.Images;

namespace Raccord.Application.Services.ScriptLocations
{
    // Service used for location functionality
    public class ScriptLocationService : IScriptLocationService
    {
        private readonly IScriptLocationRepository _scriptLocationRepository;

        // Initialises a new LocationService
        public ScriptLocationService(IScriptLocationRepository locationRepository)
        {
            if(locationRepository == null)
                throw new ArgumentNullException(nameof(locationRepository));
            
            _scriptLocationRepository = locationRepository;
        }

        // Gets all locations
        public IEnumerable<ScriptLocationSummaryDto> GetAllForParent(long projectID)
        {
            var locations = _scriptLocationRepository.GetAllForProject(projectID);

            var dtos = locations.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single location by id
        public FullScriptLocationDto Get(long ID)
        {
            var location = _scriptLocationRepository.GetFull(ID);

            var dto = location.TranslateFull();

            return dto;
        }

        // Gets a summary of a single location
        public ScriptLocationSummaryDto GetSummary(long ID)
        {
            var location = _scriptLocationRepository.GetSingle(ID);

            var dto = location.TranslateSummary();

            return dto;
        }

        // Adds a location
        public long Add(ScriptLocationDto dto)
        {
            var location = new ScriptLocation
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _scriptLocationRepository.Add(location);
            _scriptLocationRepository.Commit();

            return location.ID;
        }

        // Updates a location
        public long Update(ScriptLocationDto dto)
        {
            var location = _scriptLocationRepository.GetSingle(dto.ID);

            location.Name = dto.Name;
            location.Description = dto.Description;

            _scriptLocationRepository.Edit(location);
            _scriptLocationRepository.Commit();

            return location.ID;
        }

        // Deletes a location
        public void Delete(Int64 ID)
        {
            var location = _scriptLocationRepository.GetSingle(ID);

            _scriptLocationRepository.Delete(location);

            _scriptLocationRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toLocation = _scriptLocationRepository.GetFull(toID);
            var mergeLocation = _scriptLocationRepository.GetFull(mergeID);

            var sceneList = toLocation.Scenes.ToList();
            sceneList.AddRange(mergeLocation.Scenes);

            toLocation.Scenes = sceneList;
            mergeLocation.Scenes.Clear();

            var imageList = mergeLocation.ImageLocations.ToList();

            foreach(var image in imageList)
            {
                if(!toLocation.ImageLocations.Any(cs=> cs.ImageID == image.ImageID))
                {
                    toLocation.ImageLocations.Add(new ImageScriptLocation{ImageID = image.ImageID});
                }
            }

            _scriptLocationRepository.Edit(toLocation);
            _scriptLocationRepository.Delete(mergeLocation);

            _scriptLocationRepository.Commit();
        }
    }
}