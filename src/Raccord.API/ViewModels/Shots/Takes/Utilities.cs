using Raccord.API.ViewModels.Shots.Slates;
using Raccord.Application.Core.Services.Shots.Takes;

namespace Raccord.API.ViewModels.Shots.Takes
{
    public static class Utilities
    {
        public static FullTakeViewModel Translate(this FullTakeDto dto)
        {
            return new FullTakeViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Notes = dto.Notes,
                Length = dto.Length,
                Selected = dto.Selected,
                CameraRoll = dto.CameraRoll,
                SoundRoll = dto.SoundRoll,
                Slate = dto.Slate.Translate(),
            };
        }
        public static TakeSummaryViewModel Translate(this TakeSummaryDto dto)
        {
            return new TakeSummaryViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Notes = dto.Notes,
                Length = dto.Length,
                Selected = dto.Selected,
                CameraRoll = dto.CameraRoll,
                SoundRoll = dto.SoundRoll,
                Slate = dto.Slate.Translate(),
            };
        }
        public static TakeViewModel Translate(this TakeDto dto)
        {
            return new TakeViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Notes = dto.Notes,
                Length = dto.Length,
                Selected = dto.Selected,
                CameraRoll = dto.CameraRoll,
                SoundRoll = dto.SoundRoll,
                Slate = dto.Slate.Translate(),
            };
        }
        public static TakeDto Translate(this TakeViewModel vm)
        {
            return new TakeDto
            {
                ID = vm.ID,
                Number = vm.Number,
                Notes = vm.Notes,
                Length = vm.Length,
                Selected = vm.Selected,
                CameraRoll = vm.CameraRoll,
                SoundRoll = vm.SoundRoll,
                Slate = vm.Slate.Translate(),
            };
        }
    }
}