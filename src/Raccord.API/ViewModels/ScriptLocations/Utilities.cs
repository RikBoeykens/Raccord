using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.API.ViewModels.Scenes;
using System.Linq;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Locations.LocationSets;

namespace Raccord.API.ViewModels.ScriptLocations
{
    public static class Utilities
    {
        // Translates a location dto to a location viewmodel
        public static FullScriptLocationViewModel Translate(this FullScriptLocationDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new FullScriptLocationViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Images = dto.Images.Select(i=> i.Translate()),
                Sets = dto.Sets.Select(s=> s.Translate()),
            };
        }

        // Translates a location dto to a location viewmodel
        public static ScriptLocationSummaryViewModel Translate(this ScriptLocationSummaryDto dto)
        {
            if(dto == null)
            {
                return null;
            }

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
            if(dto == null)
            {
                return null;
            }

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
            if(dto == null)
            {
                return null;
            }

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
            if(vm == null)
            {
                return null;
            }

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