using Raccord.Application.Core.Services.Images;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Locations;
using Raccord.API.ViewModels.Common.SelectedEntity;
using System.Linq;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;

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
                Characters = dto.Characters.Select(s=> s.Translate()),
                BreakdownItems = dto.BreakdownItems.Select(bi=> bi.Translate()),
                IsPrimaryImage = dto.IsPrimaryImage,
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
                IsPrimaryImage = dto.IsPrimaryImage,
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

        // Translates a image dto to a image viewmodel
        public static LinkedImageViewModel Translate(this LinkedImageDto dto)
        {
            return new LinkedImageViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                FileName = dto.FileName,
                ProjectID = dto.ProjectID,
                LinkID = dto.LinkID,
                IsPrimaryImage = dto.IsPrimaryImage,
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