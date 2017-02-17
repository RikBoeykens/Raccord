using Raccord.Application.Core.Services.SceneProperties;
using Raccord.API.ViewModels.Scenes;
using System.Linq;

namespace Raccord.API.ViewModels.SceneProperties
{
    public static class Utilities
    {
        // Translates a int/ext dto to a int/ext viewmodel
        public static IntExtViewModel Translate(this IntExtDto dto)
        {
            return new IntExtViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }
        // Translates a int/ext summary dto to a int/ext summary viewmodel
        public static IntExtSummaryViewModel Translate(this IntExtSummaryDto dto)
        {
            return new IntExtSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a int/ext summary viewmodel to a dto
        public static IntExtSummaryDto Translate(this IntExtSummaryViewModel vm)
        {
            return new IntExtSummaryDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }

        // Translates a day/night dto to a day/night viewmodel
        public static FullDayNightViewModel Translate(this FullDayNightDto dto)
        {
            return new FullDayNightViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }
        // Translates a day/night summary dto to a day/night summary viewmodel
        public static DayNightSummaryViewModel Translate(this DayNightSummaryDto dto)
        {
            return new DayNightSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
            };
        }
        // Translates a day/night summary dto to a day/night summary viewmodel
        public static DayNightViewModel Translate(this DayNightDto dto)
        {
            return new DayNightViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a day/night summary viewmodel to a dto
        public static DayNightDto Translate(this DayNightViewModel vm)
        {
            return new DayNightDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}