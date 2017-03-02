using Raccord.Application.Core.Services.Locations;
using Raccord.API.ViewModels.Scenes;
using System.Linq;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Locations
{
    public static class Utilities
    {
        // Translates a location dto to a location viewmodel
        public static FullLocationViewModel Translate(this FullLocationDto dto)
        {
            return new FullLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Images = dto.Images.Select(i=> i.Translate()),
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }

        // Translates a location dto to a location viewmodel
        public static LocationSummaryViewModel Translate(this LocationSummaryDto dto)
        {
            return new LocationSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }

        // Translates a location dto to a location viewmodel
        public static LocationViewModel Translate(this LocationDto dto)
        {
            return new LocationSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a location viewmodel to a dto
        public static LocationDto Translate(this LocationViewModel vm)
        {
            return new LocationDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}