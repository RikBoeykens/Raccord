using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.API.ViewModels.Scenes;
using System.Linq;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.ScriptLocations
{
    public static class Utilities
    {
        // Translates a location dto to a location viewmodel
        public static FullScriptLocationViewModel Translate(this FullScriptLocationDto dto)
        {
            return new FullScriptLocationViewModel
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
        public static ScriptLocationSummaryViewModel Translate(this ScriptLocationSummaryDto dto)
        {
            return new ScriptLocationSummaryViewModel
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
        public static ScriptLocationViewModel Translate(this ScriptLocationDto dto)
        {
            return new ScriptLocationSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a location dto to a location viewmodel
        public static LinkedScriptLocationViewModel Translate(this LinkedScriptLocationDto dto)
        {
            return new LinkedScriptLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                LinkID = dto.LinkID
            };
        }

        // Translates a location viewmodel to a dto
        public static ScriptLocationDto Translate(this ScriptLocationViewModel vm)
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