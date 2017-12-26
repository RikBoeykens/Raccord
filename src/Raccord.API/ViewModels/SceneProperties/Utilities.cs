using Raccord.Application.Core.Services.SceneProperties;
using Raccord.API.ViewModels.Scenes;
using System.Linq;

namespace Raccord.API.ViewModels.SceneProperties
{
    public static class Utilities
    {
        // Translates a int/ext dto to a int/ext viewmodel
        public static FullIntExtViewModel Translate(this FullIntExtDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new FullIntExtViewModel
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
            if(dto == null)
            {
                return null;
            }

            return new IntExtSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
            };
        }
        // Translates a int/ext dto to a int/ext viewmodel
        public static IntExtViewModel Translate(this IntExtDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new IntExtViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a int/ext summary viewmodel to a dto
        public static IntExtDto Translate(this IntExtViewModel vm)
        {
            if(vm == null)
            {
                return null;
            }

            return new IntExtDto
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
            if(dto == null)
            {
                return null;
            }

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
            if(dto == null)
            {
                return null;
            }

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
            if(dto == null)
            {
                return null;
            }

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
            if(vm == null)
            {
                return null;
            }

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