using System;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDayViewModel : BaseShootingDayViewModel
    {
        public long CrewUnitID { get; set; }
    }
}