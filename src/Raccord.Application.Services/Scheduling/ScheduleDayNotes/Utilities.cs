using System.Linq;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Scheduling.ScheduleScenes;

namespace Raccord.Application.Services.Scheduling.ScheduleDayNotes
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullScheduleDayNoteDto TranslateFull(this ScheduleDayNote scheduleDayNote)
        {
            var dto = new FullScheduleDayNoteDto
            {
                ID = scheduleDayNote.ID,
                Content = scheduleDayNote.Content,
                ScheduleDayID = scheduleDayNote.ScheduleDayID,
            };

            return dto;
        }
        public static ScheduleDayNoteSummaryDto TranslateSummary(this ScheduleDayNote scheduleDayNote)
        {
            var dto = new ScheduleDayNoteSummaryDto
            {
                ID = scheduleDayNote.ID,
                Content = scheduleDayNote.Content,
                ScheduleDayID = scheduleDayNote.ScheduleDayID,
            };

            return dto;
        }

        public static ScheduleDayNoteDto Translate(this ScheduleDayNote scheduleDayNote)
        {
            var dto = new ScheduleDayNoteDto
            {
                ID = scheduleDayNote.ID,
                Content = scheduleDayNote.Content,
                ScheduleDayID = scheduleDayNote.ScheduleDayID,
            };

            return dto;
        }
    }
}