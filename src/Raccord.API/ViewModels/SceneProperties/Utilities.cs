using Raccord.Application.Core.Services.SceneProperties;
using Raccord.API.ViewModels.Scenes;
using System.Linq;

namespace Raccord.API.ViewModels.SceneProperties
{
    public static class Utilities
    {
        // Translates a int/ext dto to a int/ext viewmodel
        public static FullSceneIntroViewModel Translate(this FullSceneIntroDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new FullSceneIntroViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }
        // Translates a int/ext summary dto to a int/ext summary viewmodel
        public static SceneIntroSummaryViewModel Translate(this SceneIntroSummaryDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new SceneIntroSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
            };
        }
        // Translates a int/ext dto to a int/ext viewmodel
        public static SceneIntroViewModel Translate(this SceneIntroDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new SceneIntroViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a int/ext summary viewmodel to a dto
        public static SceneIntroDto Translate(this SceneIntroViewModel vm)
        {
            if(vm == null)
            {
                return null;
            }

            return new SceneIntroDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }

        // Translates a day/night dto to a day/night viewmodel
        public static FullTimeOfDayViewModel Translate(this FullTimeOfDayDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new FullTimeOfDayViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }
        // Translates a day/night summary dto to a day/night summary viewmodel
        public static TimeOfDaySummaryViewModel Translate(this TimeOfDaySummaryDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new TimeOfDaySummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
            };
        }
        // Translates a day/night summary dto to a day/night summary viewmodel
        public static TimeOfDayViewModel Translate(this TimeOfDayDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new TimeOfDayViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a day/night summary viewmodel to a dto
        public static TimeOfDayDto Translate(this TimeOfDayViewModel vm)
        {
            if(vm == null)
            {
                return null;
            }

            return new TimeOfDayDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}