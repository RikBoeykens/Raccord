using System;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDayNotes
{
    // Dto to represent notes on a schedule day
    public class ScheduleDayNoteViewModel
    {
        // ID of the schedule day note
        public long ID { get; set; }

        // Content of the note
        public string Content { get; set; }

        // ID of the parent schedule day
        public long ScheduleDayID { get; set; }
    }
}