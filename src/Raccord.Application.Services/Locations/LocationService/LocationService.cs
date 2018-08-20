using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Data.EntityFramework.Repositories.Locations.Locations;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Domain.Model.Locations.Locations;

namespace Raccord.Application.Services.Locations.Locations
{
    // Service used for location functionality
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IShootingDayRepository _shootingDayRepository;
        private readonly ICommentService _commentService;

        // Initialises a new LocationService
        public LocationService(
            ILocationRepository locationRepository,
            IShootingDayRepository shootingDayRepository,
            ICommentService commentService
            )
        {
            _locationRepository = locationRepository;
            _shootingDayRepository = shootingDayRepository;
            _commentService = commentService;
        }

        // Gets all locations
        public IEnumerable<LocationSummaryDto> GetAllForParent(long projectID)
        {
            var locations = _locationRepository.GetAllForProject(projectID);

            var dtos = locations.Select(l => l.TranslateSummary());

            return dtos;
        }

        public PagedDataDto<LocationSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId)
        {
            var locations = _locationRepository.GetAllForProject(projectId);
            return locations.GetPaged<Location, LocationSummaryDto>(paginationRequest, x => x.TranslateSummary());
        }

        // Gets a single schedule day by id
        public FullLocationDto Get(long ID)
        {
            var location = _locationRepository.GetFull(ID);

            var comments = _commentService.GetForParent(new GetCommentDto {ParentID = location.ID, ParentType = ParentCommentType.Location }).ToList();

            var shootingDays = _shootingDayRepository.GetAllForLocationSets(location.LocationSets.Select(ls => ls.ID).ToArray()).ToList();
            var dto = location.TranslateFull(comments, shootingDays);

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