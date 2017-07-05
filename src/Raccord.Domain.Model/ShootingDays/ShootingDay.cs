using System;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Domain.Model.ShootingDays
{
    public class ShootingDay : Entity
    {
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
    }
}