using System;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDayViewModel
    {
        // ID of the shooting day
        public long ID { get; set; }

        // Number of the shooting day
        public string Number { get; set; }

        // Date of the shooting day
        public DateTime Date { get; set; }

        public long ProjectID { get; set; }
    }
}