using System;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a callsheet
    public class CallsheetDto
    {
        private ShootingDayDto _shootingDay;

        // ID of the callsheet
        public long ID { get; set; }

        // ID of the project
        public long ProjectID { get; set; }

        // Start of the day
        public DateTime Start { get; set; }

        // End of the day
        public DateTime End { get; set; }

        // Crewcall
        public DateTime CrewCall { get; set; }

        // Linked shooting day
        public ShootingDayDto ShootingDay
        {
            get
            {
                return _shootingDay ?? (_shootingDay = new ShootingDayDto());
            }
            set
            {
                _shootingDay = value;
            }
        }
    }
}