using Raccord.Application.Core.Services.Images;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Locations;
using System.Linq;

namespace Raccord.API.ViewModels.Images
{
    public static class Utilities
    {
        // Translates a image dto to a image viewmodel
        public static FullImageViewModel Translate(this FullImageDto dto)
        {
            return new FullImageViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                FileName = dto.FileName,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Locations = dto.Locations.Select(s=> s.Translate()),
            };
        }

        // Translates a image dto to a image viewmodel
        public static ImageSummaryViewModel Translate(this ImageSummaryDto dto)
        {
            return new ImageSummaryViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                FileName = dto.FileName,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a image dto to a image viewmodel
        public static ImageViewModel Translate(this ImageDto dto)
        {
            return new ImageViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                FileName = dto.FileName,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a image viewmodel to a dto
        public static ImageDto Translate(this ImageViewModel vm)
        {
            return new ImageDto
            {
                ID = vm.ID,
                Title = vm.Title,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}