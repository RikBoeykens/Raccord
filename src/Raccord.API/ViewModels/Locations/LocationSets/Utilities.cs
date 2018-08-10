using System.Linq;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.Common.Location;
using Raccord.API.ViewModels.Locations.Locations;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.ShootingDays;
using Raccord.Application.Core.Services.Locations.LocationSets;

namespace Raccord.API.ViewModels.Locations.LocationSets
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullLocationSetViewModel Translate(this FullLocationSetDto dto)
        {
            return new FullLocationSetViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                Location = dto.Location.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
                ShootingDays = dto.ShootingDays.Select(sd=> sd.Translate()),
                Comments = dto.Comments.Select(sd=> sd.Translate())
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static LocationSetLocationViewModel Translate(this LocationSetLocationDto dto)
        {
            return new LocationSetLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                Location = dto.Location.Translate(),
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static LocationSetScriptLocationViewModel Translate(this LocationSetScriptLocationDto dto)
        {
            return new LocationSetScriptLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static LocationSetViewModel Translate(this LocationSetDto dto)
        {
            return new LocationSetViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                LocationID = dto.LocationID,
                ScriptLocationID = dto.ScriptLocationID,
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static LocationSetSummaryViewModel Translate(this LocationSetSummaryDto dto)
        {
            return new LocationSetSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                Location = dto.Location.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static LinkedLocationSetViewModel Translate(this LinkedLocationSetDto dto)
        {
            return new LinkedLocationSetViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                Location = dto.Location.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
                LinkID = dto.LinkID,
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static CallsheetLocationSetViewModel Translate(this CallsheetLocationSetDto dto)
        {
            return new CallsheetLocationSetViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LatLng = dto.LatLng.Translate(),
                ScriptLocation = dto.ScriptLocation.Translate(),
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static LocationSetDto Translate(this LocationSetViewModel vm)
        {
            return new LocationSetDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                LatLng = vm.LatLng.Translate(),
                LocationID = vm.LocationID,
                ScriptLocationID = vm.ScriptLocationID,
            };
        }
    }
}