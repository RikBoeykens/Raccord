using System.Linq;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.ShootingDays;
using Raccord.Application.Core.Services.Callsheets;

namespace Raccord.API.ViewModels.Callsheets
{
    public static class Utilities
    {
        public static FullCallsheetViewModel Translate(this FullCallsheetDto dto)
        {
            return new FullCallsheetViewModel
            {
                ID = dto.ID,
                ProjectID = dto.ProjectID,
                ShootingDay = dto.ShootingDay.Translate(),
                Scenes = dto.Scenes.Select(s=> s.Translate()),
            };
        }
        public static CallsheetSummaryViewModel Translate(this CallsheetSummaryDto dto)
        {
            return new CallsheetSummaryViewModel
            {
                ID = dto.ID,
                ProjectID = dto.ProjectID,
                ShootingDay = dto.ShootingDay.Translate(),
            };
        }
        public static CallsheetViewModel Translate(this CallsheetDto dto)
        {
            return new CallsheetViewModel
            {
                ID = dto.ID,
                ProjectID = dto.ProjectID,
                ShootingDay = dto.ShootingDay.Translate(),
            };
        }
        public static CallsheetDto Translate(this CallsheetViewModel vm)
        {
            return new CallsheetDto
            {
                ID = vm.ID,
                ProjectID = vm.ProjectID,
                ShootingDay = vm.ShootingDay.Translate(),
            };
        }
    }
}