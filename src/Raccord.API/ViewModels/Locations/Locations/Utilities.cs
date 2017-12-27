using System.Linq;
using Raccord.API.ViewModels.Common.Location;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Locations.Locations;

namespace Raccord.API.ViewModels.Locations.Locations
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullLocationViewModel Translate(this FullLocationDto dto)
        {
            return new FullLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address.Translate(),
                LatLng = dto.LatLng.Translate(),
                Sets = dto.Sets.Select(s=> s.Translate()),
                ScheduleDays = dto.ScheduleDays.Select(sd=> sd.Translate()),
                ProjectID = dto.ProjectID,
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static LocationSummaryViewModel Translate(this LocationSummaryDto dto)
        {
            return new LocationSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address.Translate(),
                LatLng = dto.LatLng.Translate(),
                SetCount = dto.SetCount,
                ProjectID = dto.ProjectID,
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static LocationViewModel Translate(this LocationDto dto)
        {
            return new LocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address.Translate(),
                LatLng = dto.LatLng.Translate(),
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static CallsheetLocationViewModel Translate(this CallsheetLocationDto dto)
        {
            return new CallsheetLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address.Translate(),
                LatLng = dto.LatLng.Translate(),
                ProjectID = dto.ProjectID,
                Number = dto.Number,
                Sets = dto.Sets.Select(s=> s.Translate())
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static LocationDto Translate(this LocationViewModel vm)
        {
            return new LocationDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                Address = vm.Address.Translate(),
                LatLng = vm.LatLng.Translate(),
                ProjectID = vm.ProjectID,
            };
        }
    }
}