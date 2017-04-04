using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDayNotes
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullScheduleDayNoteViewModel Translate(this FullScheduleDayNoteDto dto)
        {
            return new FullScheduleDayNoteViewModel
            {
                ID = dto.ID,
                Content = dto.Content,
                ScheduleDayID = dto.ScheduleDayID,
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static ScheduleDayNoteSummaryViewModel Translate(this ScheduleDayNoteSummaryDto dto)
        {
            return new ScheduleDayNoteSummaryViewModel
            {
                ID = dto.ID,
                Content = dto.Content,
                ScheduleDayID = dto.ScheduleDayID,
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static ScheduleDayNoteViewModel Translate(this ScheduleDayNoteDto dto)
        {
            return new ScheduleDayNoteViewModel
            {
                ID = dto.ID,
                Content = dto.Content,
                ScheduleDayID = dto.ScheduleDayID,
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static ScheduleDayNoteDto Translate(this ScheduleDayNoteViewModel vm)
        {
            return new ScheduleDayNoteDto
            {
                ID = vm.ID,
                Content = vm.Content,
                ScheduleDayID = vm.ScheduleDayID,
            };
        }
    }
}