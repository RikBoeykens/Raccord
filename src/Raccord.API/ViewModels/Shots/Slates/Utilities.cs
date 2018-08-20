using System.Linq;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.Images;
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
                Filters = dto.Filters,
                Sound = dto.Sound,
                IsVfx = dto.IsVfx,
                ProjectID = dto.ProjectID,
                Scene = dto.Scene.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
                Takes = dto.Takes.Select(t=> t.Translate()),
                Images = dto.Images.Select(i=> i.Translate()),
                Comments = dto.Comments.Select(c => c.Translate())
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
                Filters = dto.Filters,
                Sound = dto.Sound,
                IsVfx = dto.IsVfx,
                ProjectID = dto.ProjectID,
                Scene = dto.Scene.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
                TakeCount = dto.TakeCount,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }
        public static LinkedSlateViewModel Translate(this LinkedSlateDto dto)
        {
            return new LinkedSlateViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Description = dto.Description,
                Lens = dto.Lens,
                Distance = dto.Distance,
                Aperture = dto.Aperture,
                Filters = dto.Filters,
                Sound = dto.Sound,
                IsVfx = dto.IsVfx,
                ProjectID = dto.ProjectID,
                Scene = dto.Scene.Translate(),
                ShootingDay = dto.ShootingDay.Translate(),
                LinkID = dto.LinkID,
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
                Filters = dto.Filters,
                Sound = dto.Sound,
                IsVfx = dto.IsVfx,
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
                Filters = vm.Filters,
                Sound = vm.Sound,
                IsVfx = vm.IsVfx,
                ProjectID = vm.ProjectID,
                Scene = vm.Scene.Translate(),
                ShootingDay = vm.ShootingDay.Translate(),
            };
        }
    }
}