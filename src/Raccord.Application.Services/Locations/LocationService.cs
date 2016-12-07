using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Locations;
using Raccord.Application.Core.Services.Locations;
using Raccord.Data.EntityFramework.Repositories.Locations;

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
        public IEnumerable<LocationSummaryDto> GetAllForProject(long projectID)
        {
            var locations = _locationRepository.GetAllForProject(projectID);

            var locationDtos = locations.Select(l => l.TranslateSummary());

            return locationDtos;
        }

        // Gets a single location by id
        public LocationDto Get(Int64 ID)
        {
            var location = _locationRepository.GetFull(ID);

            var locationDto = location.Translate();

            return locationDto;
        }

        // Gets a summary of a single location
        public LocationSummaryDto GetSummary(Int64 ID)
        {
            var location = _locationRepository.GetSingle(ID);

            var locationDto = location.TranslateSummary();

            return locationDto;
        }

        // Adds a location
        public long Add(LocationSummaryDto dto)
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
        public long Update(LocationSummaryDto dto)
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
    }
}