using System;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a day in a schedule
    public class BaseScheduleDayDto
    {
        // ID of the schedule day
        public long ID { get; set; }

        /// Date of the schedule day
        public DateTime Date { get; set; }

        /// Date of the schedule day
        public DateTime? Start { get; set; }

        /// Date of the schedule day
        public DateTime? End { get; set; }
    }
}