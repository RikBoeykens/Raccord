using System;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Domain.Model.Callsheets
{
    public class Callsheet : Entity
    {
        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked shooting day
        public long ShootingDayID { get; set; }

        // Linked shooting day
        public virtual ShootingDay ShootingDay { get; set; }
    }
}