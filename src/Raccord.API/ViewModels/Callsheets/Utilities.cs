using System.Linq;
using Raccord.API.ViewModels.Breakdowns;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.Callsheets.Characters;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Locations.Locations;
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
                CrewUnit = dto.CrewUnit.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Characters = dto.Characters.Select(c=> c.Translate()),
                Locations = dto.Locations.Select(l=> l.Translate()),
                BreakdownInfo = dto.BreakdownInfo.Translate(),
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
                CrewUnitID = dto.CrewUnitID,
                ShootingDay = dto.ShootingDay.Translate(),
            };
        }
        public static CallsheetCrewUnitViewModel Translate(this CallsheetCrewUnitDto dto)
        {
            return new CallsheetCrewUnitViewModel
            {
                ID = dto.ID,
                Start = dto.Start,
                End = dto.End,
                CrewCall = dto.CrewCall,
                CrewUnit = dto.CrewUnit.Translate(),
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
                CrewUnitID = dto.CrewUnitID,
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
                CrewUnitID = vm.CrewUnitID,
                ShootingDay = vm.ShootingDay.Translate(),
            };
        }
    }
}