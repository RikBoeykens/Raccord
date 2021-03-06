using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Scenes;
using System.Linq;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.ShootingDays;

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
                Breakdown = dto.Breakdown.Translate(),
                Type = dto.Type.Translate(),
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Images = dto.Images.Select(i=> i.Translate()),
                Comments = dto.Comments.Select(c => c.Translate()),
                ShootingDays = dto.ShootingDays.Select(s => s.Translate())
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
                BreakdownID = dto.BreakdownID,
                BreakdownTypeID = dto.BreakdownTypeID,
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
                BreakdownID = dto.BreakdownID,
                BreakdownTypeID = dto.BreakdownTypeID,
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
                Breakdown = dto.Breakdown.Translate(),
                LinkID = dto.LinkID,
            };
        }

        // Translates a breakdown item dto to a breakdown item viewmodel
        public static SceneBreakdownItemViewModel Translate(this SceneBreakdownItemDto dto)
        {
            return new SceneBreakdownItemViewModel
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
                BreakdownID = vm.BreakdownID,
                BreakdownTypeID = vm.BreakdownTypeID,
            };
        }

        public static SearchBreakdownItemRequestDto Translate(this SearchBreakdownItemRequestViewModel vm, string userID)
        {
            return new SearchBreakdownItemRequestDto
            {
                SearchText = vm.SearchText,
                TypeID = vm.TypeID,
                BreakdownID = vm.BreakdownID,
                UserID = userID,
                ExcludeIDs = vm.ExcludeIDs
            };
        }
    }
}