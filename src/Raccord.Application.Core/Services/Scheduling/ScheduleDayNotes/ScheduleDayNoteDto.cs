using System;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes
{
    // Dto to represent notes on a schedule day
    public class ScheduleDayNoteDto
    {
        // ID of the schedule day note
        public long ID { get; set; }

        // Content of the note
        public string Content { get; set; }

        // ID of the parent schedule day
        public long ScheduleDayID { get; set; }
    }
}