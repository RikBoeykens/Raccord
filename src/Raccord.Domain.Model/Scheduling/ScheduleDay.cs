using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Domain.Model.Scheduling
{
    /// Represents schedule day
    public class ScheduleDay : Entity<long>
    {        
        private ICollection<ScheduleScene> _scenes;
        private ICollection<ScheduleDayNote> _notes;

        // Date of the schedule day
        public DateTime Date { get; set; }

        // Time of day the schedule day starts
        public DateTime? Start { get; set; }

        // Time of day the schedule day ends
        public DateTime? End { get; set; }

        // ID of the linked project
        public long CrewUnitID { get; set; }

        // Linked project
        public virtual CrewUnit CrewUnit { get; set; }

        // ID of the linked shooting day
        public long? ShootingDayID { get; set; }

        public virtual ShootingDay ShootingDay { get; set; }

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