using Raccord.Application.Core.Services.Locations;
using Raccord.API.ViewModels.Scenes;
using System.Linq;

namespace Raccord.API.ViewModels.Locations
{
    public static class Utilities
    {
        // Translates a location dto to a location viewmodel
        public static LocationViewModel Translate(this LocationDto dto)
        {
            return new LocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }
        // Translates a location summary dto to a location summary viewmodel
        public static LocationSummaryViewModel Translate(this LocationSummaryDto dto)
        {
            return new LocationSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a location summary viewmodel to a dto
        public static LocationSummaryDto Translate(this LocationSummaryViewModel vm)
        {
            return new LocationSummaryDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}