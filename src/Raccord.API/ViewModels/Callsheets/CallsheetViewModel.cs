using System;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Callsheets
{
    // Dto to represent a callsheet
    public class CallsheetViewModel
    {
        private ShootingDayViewModel _shootingDay;

        // ID of the callsheet
        public long ID { get; set; }

        // Start of the day
        public DateTime Start { get; set; }

        // End of the day
        public DateTime End { get; set; }

        // Crewcall
        public DateTime CrewCall { get; set; }

        // ID of the project
        public long ProjectID { get; set; }

        // Linked shooting day
        public ShootingDayViewModel ShootingDay
        {
            get
            {
                return _shootingDay ?? (_shootingDay = new ShootingDayViewModel());
            }
            set
            {
                _shootingDay = value;
            }
        }
    }
}