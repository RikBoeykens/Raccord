using System;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDayDto
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