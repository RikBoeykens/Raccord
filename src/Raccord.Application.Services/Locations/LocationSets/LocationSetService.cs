using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Data.EntityFramework.Repositories.Locations.LocationSets;

namespace Raccord.Application.Services.Locations.LocationSets
{
    // Service used for location set functionality
    public class LocationSetService : ILocationSetService
    {
        private readonly ILocationSetRepository _locationSetRepository;

        // Initialises a new LocationSetService
        public LocationSetService(ILocationSetRepository locationSetRepository)
        {
            if(locationSetRepository == null)
                throw new ArgumentNullException(nameof(locationSetRepository));
            
            _locationSetRepository = locationSetRepository;
        }

        // Gets all sets for a location
        public IEnumerable<LocationSetLocationDto> GetLocations(long scriptLocationID)
        {
            var locationSets = _locationSetRepository.GetAllForScriptLocation(scriptLocationID);

            var dtos = locationSets.Select(l => l.TranslateLocation());

            return dtos;
        }

        // Gets all sets for a script location
        public IEnumerable<LocationSetScriptLocationDto> GetScriptLocations(long locationID)
        {
            var locationSets = _locationSetRepository.GetAllForLocation(locationID);

            var dtos = locationSets.Select(l => l.TranslateScriptLocation());

            return dtos;
        }

        public IEnumerable<LocationSetSummaryDto> GetSetsForScene(long sceneID)
        {
            var locationSets = _locationSetRepository.GetAllForScene(sceneID);

            var dtos = locationSets.Select(l=> l.TranslateSummary());

            return dtos;
        }

        // Gets a single locationset by id
        public FullLocationSetDto Get(long ID)
        {
            var locationSet = _locationSetRepository.GetFull(ID);

            var dto = locationSet.TranslateFull();

            return dto;
        }

        // Adds a locationset
        public long Add(LocationSetDto dto)
        {
            var locationSet = new LocationSet
            {
                Name = dto.Name,
                Description = dto.Description,
                Latitude = dto.LatLng.Latitude,
                Longitude = dto.LatLng.Longitude,
                LocationID = dto.LocationID,
                ScriptLocationID = dto.ScriptLocationID,
            };

            _locationSetRepository.Add(locationSet);
            _locationSetRepository.Commit();

            return locationSet.ID;
        }

        // Updates a locationset
        public long Update(LocationSetDto dto)
        {
            var locationSet = _locationSetRepository.GetSingle(dto.ID);

            locationSet.Name = dto.Name;
            locationSet.Description = dto.Description;
            locationSet.Latitude = dto.LatLng.Latitude;
            locationSet.Longitude = dto.LatLng.Longitude;

            _locationSetRepository.Edit(locationSet);
            _locationSetRepository.Commit();

            return locationSet.ID;
        }

        // Deletes a locationset
        public void Delete(Int64 ID)
        {
            var locationSet = _locationSetRepository.GetSingle(ID);

            _locationSetRepository.Delete(locationSet);

            _locationSetRepository.Commit();
        }
    }
}