using System;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Domain.Model.Callsheets
{
    public class Callsheet : Entity
    {
        public string Number { get; set; }

        // Date of the shooting day
        public DateTime Date { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        public long? ShootingDayID { get; set; }

        public virtual ShootingDay ShootingDay { get; set; }
    }
}