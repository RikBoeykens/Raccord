using Raccord.API.ViewModels.Images;
using Raccord.Application.Core.Services.Projects;

namespace Raccord.API.ViewModels.Projects
{
    public static class Utilities
    {
        // Translates a project dto to a project viewmodel
        public static FullProjectViewModel Translate(this FullProjectDto dto)
        {
            return new FullProjectViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }
        // Translates a project summary dto to a project summary viewmodel
        public static ProjectSummaryViewModel Translate(this ProjectSummaryDto dto)
        {
            return new ProjectSummaryViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }

        // Translates a project dto to a project viewmodel
        public static ProjectViewModel Translate(this ProjectDto dto)
        {
            return new ProjectViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
            };
        }

        // Translates a project viewmodel to a dto
        public static ProjectDto Translate(this ProjectViewModel vm)
        {
            return new ProjectDto
            {
                ID = vm.ID,
                Title = vm.Title,
            };
        }
    }
}