using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Data.EntityFramework.Repositories.Locations.Locations;
using Raccord.Domain.Model.Locations.Locations;

namespace Raccord.Application.Services.Locations.Locations
{
    // Service used for location functionality
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ICommentRepository _commentRepository;

        // Initialises a new LocationService
        public LocationService(
            ILocationRepository locationRepository,
            ICommentRepository commentRepository
            )
        {
            _locationRepository = locationRepository;
            _commentRepository = commentRepository;
        }

        // Gets all locations
        public IEnumerable<LocationSummaryDto> GetAllForParent(long projectID)
        {
            var locations = _locationRepository.GetAllForProject(projectID);

            var dtos = locations.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single schedule day by id
        public FullLocationDto Get(long ID)
        {
            var location = _locationRepository.GetFull(ID);

            var comments = _commentRepository.GetForParent(location.ID, ParentCommentType.Location).ToList();

            var dto = location.TranslateFull(comments);

            return dto;
        }

        // Gets a summary of a single schedule day
        public LocationSummaryDto GetSummary(long ID)
        {
            var location = _locationRepository.GetSummary(ID);

            var dto = location.TranslateSummary();

            return dto;
        }

        // Adds a schedule day
        public long Add(LocationDto dto)
        {
            var location = new Location
            {
                Name = dto.Name,
                Description = dto.Description,
                Address1 = dto.Address.Address1,
                Address2 = dto.Address.Address2,
                Address3 = dto.Address.Address3,
                Address4 = dto.Address.Address4,
                Latitude = dto.LatLng.Latitude,
                Longitude = dto.LatLng.Longitude,
                ProjectID = dto.ProjectID
            };

            _locationRepository.Add(location);
            _locationRepository.Commit();

            return location.ID;
        }

        // Updates a schedule day
        public long Update(LocationDto dto)
        {
            var location = _locationRepository.GetSingle(dto.ID);

            location.Name = dto.Name;
            location.Description = dto.Description;
            location.Address1 = dto.Address.Address1;
            location.Address2 = dto.Address.Address2;
            location.Address3 = dto.Address.Address3;
            location.Address4 = dto.Address.Address4;
            location.Latitude = dto.LatLng.Latitude;
            location.Longitude = dto.LatLng.Longitude;

            _locationRepository.Edit(location);
            _locationRepository.Commit();

            return location.ID;
        }

        // Deletes a schedule day
        public void Delete(Int64 ID)
        {
            var location = _locationRepository.GetSingle(ID);

            _locationRepository.Delete(location);

            _locationRepository.Commit();
        }
    }
}