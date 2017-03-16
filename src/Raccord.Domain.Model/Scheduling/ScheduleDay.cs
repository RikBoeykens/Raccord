using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Scheduling
{
    /// Represents schedule day
    public class ScheduleDay : Entity
    {        
        private ICollection<ScheduleScene> _scenes;
        private ICollection<ScheduleDayNote> _notes;

        // Date of the schedule day
        public DateTime Date { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // Linked scenes
        public virtual ICollection<ScheduleScene> ScheduleScenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ScheduleScene>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Linked notes
        public virtual ICollection<ScheduleDayNote> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<ScheduleDayNote>());
            }
            set
            {
                _notes = value;
            }
        }
    }
}