using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Raccord.Domain.Model.Callsheets;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Domain.Model.ShootingDays.Scenes;
using Raccord.Domain.Model.Shots;

namespace Raccord.Domain.Model.ShootingDays
{
    public class ShootingDay : Entity
    {
        private ICollection<Slate> _slates;
        private ICollection<ShootingDayScene> _scenes;
        
        // Number of the shooting day
        public string Number { get; set; }

        // Date of the shooting day
        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime Turn { get; set; }

        public DateTime End { get; set; }

        public TimeSpan OverTime { get; set; }

        public bool Completed { get; set; }

        // ID of the linked project
        public long CrewUnitID { get; set; }

        // Linked project
        public virtual CrewUnit CrewUnit { get; set; }

        public long? ScheduleDayID { get; set; }

        public virtual ScheduleDay ScheduleDay { get; set; }

        public long? CallsheetID { get; set; }

        public virtual Callsheet Callsheet { get; set; }

        // Linked slates
        public virtual ICollection<Slate> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<Slate>());
            }
            set
            {
                _slates = value;
            }
        }

        // Linked shooting day scenes
        public virtual ICollection<ShootingDayScene> ShootingDayScenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ShootingDayScene>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}