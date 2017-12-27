using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using System.Linq;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Breakdowns.BreakdownItemScenes;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownTypes
{
    public static class Utilities
    {
        // Translates a full breakdown type dto to a full breakdown type viewmodel
        public static FullBreakdownTypeViewModel Translate(this FullBreakdownTypeDto dto)
        {
            return new FullBreakdownTypeViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                BreakdownItems = dto.BreakdownItems.Select(bi=> bi.Translate()),
            };
        }

        // Translates a breakdown type summary dto to a breakdown type summary viewmodel
        public static BreakdownTypeSummaryViewModel Translate(this BreakdownTypeSummaryDto dto)
        {
            return new BreakdownTypeSummaryViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                ItemCount = dto.ItemCount,
            };
        }

        // Translates a breakdown type dto to a breakdown type viewmodel
        public static CallsheetBreakdownTypeViewModel Translate(this CallsheetBreakdownTypeDto dto)
        {
            if(dto == null)
            {
                return null;
            }
            
            return new CallsheetBreakdownTypeViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }

        // Translates a breakdown type dto to a breakdown type viewmodel
        public static BreakdownTypeViewModel Translate(this BreakdownTypeDto dto)
        {
            return new BreakdownTypeViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a breakdown type viewmodel to a dto
        public static BreakdownTypeDto Translate(this BreakdownTypeViewModel vm)
        {
            return new BreakdownTypeDto
            {
                ID = vm.ID,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}