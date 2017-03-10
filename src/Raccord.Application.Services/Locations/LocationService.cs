using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Locations;
using Raccord.Application.Core.Services.Locations;
using Raccord.Data.EntityFramework.Repositories.Locations;
using Raccord.Domain.Model.Images;

namespace Raccord.Application.Services.Locations
{
    // Service used for location functionality
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        // Initialises a new LocationService
        public LocationService(ILocationRepository locationRepository)
        {
            if(locationRepository == null)
                throw new ArgumentNullException(nameof(locationRepository));
            
            _locationRepository = locationRepository;
        }

        // Gets all locations
        public IEnumerable<LocationSummaryDto> GetAllForParent(long projectID)
        {
            var locations = _locationRepository.GetAllForProject(projectID);

            var dtos = locations.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single location by id
        public FullLocationDto Get(long ID)
        {
            var location = _locationRepository.GetFull(ID);

            var dto = location.TranslateFull();

            return dto;
        }

        // Gets a summary of a single location
        public LocationSummaryDto GetSummary(long ID)
        {
            var location = _locationRepository.GetSingle(ID);

            var dto = location.TranslateSummary();

            return dto;
        }

        // Adds a location
        public long Add(LocationDto dto)
        {
            var location = new Location
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _locationRepository.Add(location);
            _locationRepository.Commit();

            return location.ID;
        }

        // Updates a location
        public long Update(LocationDto dto)
        {
            var location = _locationRepository.GetSingle(dto.ID);

            location.Name = dto.Name;
            location.Description = dto.Description;

            _locationRepository.Edit(location);
            _locationRepository.Commit();

            return location.ID;
        }

        // Deletes a location
        public void Delete(Int64 ID)
        {
            var location = _locationRepository.GetSingle(ID);

            _locationRepository.Delete(location);

            _locationRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toLocation = _locationRepository.GetFull(toID);
            var mergeLocation = _locationRepository.GetFull(mergeID);

            var sceneList = toLocation.Scenes.ToList();
            sceneList.AddRange(mergeLocation.Scenes);

            toLocation.Scenes = sceneList;
            mergeLocation.Scenes.Clear();

            var imageList = mergeLocation.ImageLocations.ToList();

            foreach(var image in imageList)
            {
                if(!toLocation.ImageLocations.Any(cs=> cs.ImageID == image.ImageID))
                {
                    toLocation.ImageLocations.Add(new ImageLocation{ImageID = image.ImageID});
                }
            }

            _locationRepository.Edit(toLocation);
            _locationRepository.Delete(mergeLocation);

            _locationRepository.Commit();
        }
    }
}