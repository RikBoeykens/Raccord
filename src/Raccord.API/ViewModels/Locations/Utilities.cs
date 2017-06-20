using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.API.ViewModels.Scenes;
using System.Linq;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Locations
{
    public static class Utilities
    {
        // Translates a location dto to a location viewmodel
        public static FullLocationViewModel Translate(this FullScriptLocationDto dto)
        {
            return new FullLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Images = dto.Images.Select(i=> i.Translate()),
            };
        }

        // Translates a location dto to a location viewmodel
        public static LocationSummaryViewModel Translate(this ScriptLocationSummaryDto dto)
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
        public static LocationViewModel Translate(this ScriptLocationDto dto)
        {
            return new LocationSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a location dto to a location viewmodel
        public static LinkedLocationViewModel Translate(this LinkedScriptLocationDto dto)
        {
            return new LinkedLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                LinkID = dto.LinkID
            };
        }

        // Translates a location viewmodel to a dto
        public static ScriptLocationDto Translate(this LocationViewModel vm)
        {
            return new ScriptLocationDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}