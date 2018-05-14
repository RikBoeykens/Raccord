using System;
using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Vm to represent info about a shooting day
    public class ShootingDayInfoViewModel
    {
        private CrewUnitViewModel _crewUnit;
        // ID of the shooting day
        public long ID { get; set; }

        // Number of the shooting day
        public string Number { get; set; }

        // Date of the shooting day
        public DateTime Date { get; set; }

        // Type of shooting day
        public ShootingDayType Type { get; set; }

        public CrewUnitViewModel CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitViewModel();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}