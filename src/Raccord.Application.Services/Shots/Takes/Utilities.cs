using System.Linq;
using Raccord.Application.Core.Services.Shots.Takes;
using Raccord.Application.Services.Shots.Slates;
using Raccord.Domain.Model.Shots;

namespace Raccord.Application.Services.Shots.Takes
{
    public static class Utilities
    {
        public static FullTakeDto TranslateFull(this Take take)
        {
            return new FullTakeDto
            {
                ID = take.ID,
                Number = take.Number,
                Notes = take.Notes,
                Length = take.Length,
                Selected = take.Selected,
                CameraRoll = take.CameraRoll,
                SoundRoll = take.SoundRoll,
                Slate = take.Slate.Translate(),
            };
        }
        public static TakeSummaryDto TranslateSummary(this Take take)
        {
            return new TakeSummaryDto
            {
                ID = take.ID,
                Number = take.Number,
                Notes = take.Notes,
                Length = take.Length,
                Selected = take.Selected,
                CameraRoll = take.CameraRoll,
                SoundRoll = take.SoundRoll,
                Slate = take.Slate.Translate(),
            };
        }
        public static TakeDto Translate(this Take take)
        {
            return new TakeDto
            {
                ID = take.ID,
                Number = take.Number,
                Notes = take.Notes,
                Length = take.Length,
                Selected = take.Selected,
                CameraRoll = take.CameraRoll,
                SoundRoll = take.SoundRoll,
                Slate = take.Slate.Translate(),
            };
        }
    }
}