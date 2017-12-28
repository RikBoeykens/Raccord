using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Scenes;
using System.Linq;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    public static class Utilities
    {
        // Translates a breakdown item dto to a breakdown item viewmodel
        public static FullBreakdownItemViewModel Translate(this FullBreakdownItemDto dto)
        {
            return new FullBreakdownItemViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type.Translate(),
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Images = dto.Images.Select(i=> i.Translate()),
            };
        }

        // Translates a breakdown item dto to a breakdown item viewmodel
        public static BreakdownItemSummaryViewModel Translate(this BreakdownItemSummaryDto dto)
        {
            return new BreakdownItemSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type.Translate(),
                SceneCount = dto.SceneCount,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }

        // Translates a breakdown item dto to a breakdown item viewmodel
        public static BreakdownItemViewModel Translate(this BreakdownItemDto dto)
        {
            return new BreakdownItemViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type.Translate(),
            };
        }

        // Translates a breakdown item dto to a breakdown item viewmodel
        public static CallsheetBreakdownItemViewModel Translate(this CallsheetBreakdownItemDto dto)
        {
            return new CallsheetBreakdownItemViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
            };
        }

        // Translates a breakdown item dto to a breakdown item viewmodel
        public static LinkedBreakdownItemViewModel Translate(this LinkedBreakdownItemDto dto)
        {
            return new LinkedBreakdownItemViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type.Translate(),
                LinkID = dto.LinkID
            };
        }

        // Translates a breakdown item viewmodel to a dto
        public static BreakdownItemDto Translate(this BreakdownItemViewModel vm)
        {
            return new BreakdownItemDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                Type = vm.Type.Translate(),
            };
        }
    }
}