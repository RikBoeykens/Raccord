using System.Linq;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.Callsheets.Characters;
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
                Start = dto.Start,
                End = dto.End,
                CrewCall = dto.CrewCall,
                ProjectID = dto.ProjectID,
                ShootingDay = dto.ShootingDay.Translate(),
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Characters = dto.Characters.Select(c=> c.Translate()),
            };
        }
        public static CallsheetSummaryViewModel Translate(this CallsheetSummaryDto dto)
        {
            return new CallsheetSummaryViewModel
            {
                ID = dto.ID,
                Start = dto.Start,
                End = dto.End,
                CrewCall = dto.CrewCall,
                ProjectID = dto.ProjectID,
                ShootingDay = dto.ShootingDay.Translate(),
            };
        }
        public static CallsheetViewModel Translate(this CallsheetDto dto)
        {
            return new CallsheetViewModel
            {
                ID = dto.ID,
                Start = dto.Start,
                End = dto.End,
                CrewCall = dto.CrewCall,
                ProjectID = dto.ProjectID,
                ShootingDay = dto.ShootingDay.Translate(),
            };
        }
        public static CallsheetDto Translate(this CallsheetViewModel vm)
        {
            return new CallsheetDto
            {
                ID = vm.ID,
                Start = vm.Start,
                End = vm.End,
                CrewCall = vm.CrewCall,
                ProjectID = vm.ProjectID,
                ShootingDay = vm.ShootingDay.Translate(),
            };
        }
    }
}