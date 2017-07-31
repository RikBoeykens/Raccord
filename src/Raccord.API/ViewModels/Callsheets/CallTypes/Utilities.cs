using Raccord.Application.Core.Services.Callsheets.CallTypes;

namespace Raccord.API.ViewModels.Callsheets.CallTypes
{
    public static class Utilities
    {
        public static CallTypeViewModel Translate(this CallTypeDto dto)
        {
            return new CallTypeViewModel
            {
                ID = dto.ID,
                ShortName = dto.ShortName,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }
        public static CallTypeDto Translate(this CallTypeViewModel vm)
        {
            return new CallTypeDto
            {
                ID = vm.ID,
                ShortName = vm.ShortName,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}