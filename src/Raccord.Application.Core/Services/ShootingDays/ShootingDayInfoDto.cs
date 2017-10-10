using System;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent info about a shooting day
    public class ShootingDayInfoDto
    {
        // ID of the shooting day
        public long ID { get; set; }

        // Number of the shooting day
        public string Number { get; set; }

        // Date of the shooting day
        public DateTime Date { get; set; }

        // Type of shooting day
        public ShootingDayType Type { get; set; }
    }
}