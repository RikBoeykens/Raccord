using System;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDayDto : BaseShootingDayDto
    {
        public long CrewUnitID { get; set; }
    }
}