using Raccord.Application.Core.Services.Images;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.Common.SelectedEntity;
using System.Linq;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Shots.Slates;

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
                ScriptLocations = dto.ScriptLocations.Select(s=> s.Translate()),
                Characters = dto.Characters.Select(s=> s.Translate()),
                BreakdownItems = dto.BreakdownItems.Select(bi=> bi.Translate()),
                Slates = dto.Slates.Select(s=> s.Translate()),
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