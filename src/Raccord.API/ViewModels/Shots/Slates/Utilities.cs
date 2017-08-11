using System.Linq;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ShootingDays;
using Raccord.API.ViewModels.Shots.Takes;
using Raccord.Application.Core.Services.Shots.Slates;

namespace Raccord.API.ViewModels.Shots.Slates
{
    public static class Utilities
    {
        public static FullSlateViewModel Translate(this FullSlateDto dto)
        {
            return new FullSlateViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Description = dto.Description,
                Lens = dto.Lens,
                Distance = dto.Distance,
                Aperture = dto.Aperture,
                Sound = dto.Sound,
                ProjectID = dto.ProjectID,
                Scene = dto.Scene.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
                Takes = dto.Takes.Select(t=> t.Translate()),
            };
        }
        public static SlateSummaryViewModel Translate(this SlateSummaryDto dto)
        {
            return new SlateSummaryViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Description = dto.Description,
                Lens = dto.Lens,
                Distance = dto.Distance,
                Aperture = dto.Aperture,
                Sound = dto.Sound,
                ProjectID = dto.ProjectID,
                Scene = dto.Scene.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
                TakeCount = dto.TakeCount,
            };
        }
        public static SlateViewModel Translate(this SlateDto dto)
        {
            return new SlateViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Description = dto.Description,
                Lens = dto.Lens,
                Distance = dto.Distance,
                Aperture = dto.Aperture,
                Sound = dto.Sound,
                ProjectID = dto.ProjectID,
                Scene = dto.Scene.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
            };
        }
        public static SlateDto Translate(this SlateViewModel vm)
        {
            return new SlateDto
            {
                ID = vm.ID,
                Number = vm.Number,
                Description = vm.Description,
                Lens = vm.Lens,
                Distance = vm.Distance,
                Aperture = vm.Aperture,
                Sound = vm.Sound,
                ProjectID = vm.ProjectID,
                Scene = vm.Scene.Translate(),
                ShootingDay = vm.ShootingDay.Translate(),
            };
        }
    }
}