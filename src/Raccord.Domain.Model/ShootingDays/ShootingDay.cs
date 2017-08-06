using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Domain.Model.Shots;

namespace Raccord.Domain.Model.ShootingDays
{
    public class ShootingDay : Entity
    {
        private ICollection<Slate> _slates;
        
        // Number of the shooting day
        public string Number { get; set; }

        // Date of the shooting day
        public DateTime Date { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

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
    }
}